using Leaf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Leaf
{
    public interface ITag
    {
        string Name { get; }
        Regex BeginFormat { get; }
        Regex EndFormat { get; }
        bool SelfNest { get; }
        List<Attribute> Attributes { get; }
        List<ITag> Children { get; }
    }
    public class Tag : ITag
    {
        public string Name { get; }
        public Regex BeginFormat { get; }
        public Regex EndFormat { get; }
        public bool SelfNest { get; }
        public List<Attribute> Attributes { get; }
        public virtual List<ITag> Children { get; }
        public Tag() : this("Root", "", "") { }
        public Tag(
            string name,
            string beginFormat,
            string endFormat,
            bool selfNest = false)
        {
            Name = name;
            BeginFormat = new Regex(beginFormat);
            EndFormat = new Regex(endFormat);
            SelfNest = selfNest;
            Attributes = new List<Attribute>();
            Children = new List<ITag>();
        }
        public override string ToString() => $"{{{Name} [_beginFormat({BeginFormat}), _endFormat({EndFormat}), _selfNest({SelfNest})]}}";
    }
    public class Tag<N> : Tag
        where N : Node
    {
        public Tag() : base() { }
        public Tag(
            string name,
            string beginFormat,
            string endFormat,
            bool selfNest = false)
            : base(name, beginFormat, endFormat, selfNest) { }
    }

    public static partial class Extensions
    {
        public static T Copy<T>(this T @this) where T : Tag, new()
        {
            var result =
                (T)Activator.CreateInstance(typeof(T),
                    @this.Name,
                    @this.BeginFormat.ToString(),
                    @this.EndFormat.ToString(),
                    @this.SelfNest
                );
            foreach (var a in @this.Attributes)
                result.Attributes.Add(a.Copy());
            foreach (var c in @this.Children.OfType<Tag>())
                result.Children.Add(c.Copy());
            return result;
        }
        public static ITag AddProperty(this ITag @this, string name, string value = null)
        {
            @this.Attributes.Add(new Attribute(name, value));
            return @this;
        }
        public static string GetProperty(this ITag @this, string name)
            => @this.Attributes.FirstOrDefault(x => x.Name == name).Value;
        public static ITag SetProperty(this ITag @this, string name, string value)
        {
            @this.Attributes.FirstOrDefault(x => x.Name == name).Value = value;
            return @this;
        }
        public static N NewNode<T, N>(this T @this, string innerText)
            where T : Tag<N>
            where N : Node
            => (N)Activator.CreateInstance(typeof(N), @this, innerText);
        /// <summary>Append a child Tag in the hierarchy schema. Return the parent.</summary>
        public static T AppendChild<T>(this T @this, ITag child) where T : ITag
        {
            @this.Children.Add(child);
            return @this;
        }
        /// <summary>Append nodes to a parent element, then return the parent.</summary>
        public static INode AppendChildren(this INode @this, IEnumerable<INode> children)
        {
            @this.Children.AddRange(children);
            return @this;
        }
        /// <summary>Get first Tag match for the provied content string.</summary>
        internal static string InnerText(this ITag @this, string content, List<INode> children = null)
        {
            if (@this.SelfNest)
            {
                children = children ?? new List<INode>();
                children.Clear();
            }
            string result = null;
            //Each Regex Match has Index(int) and Length(int)
            var mBegin = @this.BeginFormat.Matches(content);
            var mEnd = @this.EndFormat.Matches(content);
            //Validate
            if (mBegin.Count != mEnd.Count)
                throw new Exception("Poorly formatted text. Missing opening or closing tag.");
            //Get string-index-order of begin or end match.
            var indexes =
                mBegin.OfType<Match>().Select(x => new NodeMatch(true, x)).Concat(
                mEnd.OfType<Match>().Select(x => new NodeMatch(false, x)))
                .OrderBy(x => x.Match.Index)
                .ToArray();
            //Compound matching.
            //Begin = -1
            //End = 1
            Func<NodeMatch, int> nestInc = x => x.Begin ? -1 : 1;
            for (int i = 0; i < indexes.Length; i++)
            {
                var n = 0;
                var index = indexes[i];
                if (index.Begin)
                {
                    //Current -> Last.
                    for (int j = i; j < indexes.Length; j++)
                    {
                        n = n + nestInc(indexes[j]);
                    }
                }
                else
                {
                    //Last -> Current+1
                    for (int j = indexes.Length - 1; j > i; j--)
                    {
                        n = n + nestInc(indexes[j]);
                    }
                }
                index.Nest = n;
            }
            //Get begin and end nodes in same nest.
            //**Nest:0 has the InnerText return value, all greater Nests are children.
            var nested = indexes
                .OrderBy(x => x.Nest)
                .ThenBy(x => x.Match.Index)
                .GroupBy(x => x.Nest)
                .Select(x => new
                {
                    Nest = x.Key,
                    Nodes = x.ToArray()
                })
                .ToArray();
            Array.Clear(indexes, 0, indexes.Length);
            Func<NodeMatch, bool> _isRoot = x => x.Nest == 0;
            for (int i = 0; i < nested.Length; i++)
            {
                var isRoot = nested[i].Nest == 0;
                var innerText = string.Empty;
                if (isRoot || @this.SelfNest)
                {
                    for (int j = 0; j < nested[i].Nodes.Length; j += 2)
                    {
                        var b = nested[i].Nodes[j];
                        if (b.Begin)
                        {
                            var e = nested[i].Nodes[j + 1];
                            if (e.Begin)
                                throw new Exception("Bad format.");
                            innerText = content
                                .Substring(0, e.Match.Index)
                                .Substring(b.Match.Index + b.Match.Length);
                            //Get result from first root Node.
                            if (j == 0 && _isRoot(b))
                                result = innerText;
                        }
                    }
                    if (isRoot)
                        break;
                }
            }
            return result;
        }
        internal static List<N> GetNodes<T, N>(this T @this, string content)
            where T : Tag<N>
            where N : Node
        {
            var result = new List<N>();
            //Get all nodes at this level.
            string nodeText = null;
            while ((nodeText = @this.InnerText(content)) != null)
            {
                var n = @this.NewNode<T, N>(nodeText);
                n.GetAttributes();
                //Remove the current nodeText from the parent's innerText.
                content = content.Substring(content.IndexOf(nodeText) + nodeText.Length);
                var firstEnd = @this.EndFormat.Match(content);
                content = content.Substring(firstEnd.Index + firstEnd.Length);
                //Add the Node, and nested Nodes.
                if (@this.SelfNest)
                    n.AppendChildren(((T)n.Tag).GetNodes<T, N>(n.InnerText));
                result.Add(n);
            }
            return result;
        }
        /// <summary>Get Child Node hierarchy.</summary>
        internal static N GetChildNodes<T, N>(this N @this)
            where T : Tag<N>
            where N : Node
        {
            foreach (var h in @this.Tag.Children)
            {
                var nodes = ((T)h).GetNodes<T, N>(@this.InnerText);
                @this.AppendChildren(nodes);
            }
            return @this;
        }
        public static N Parse<T, N>(this ITag @this, string content)
            where T : Tag<N>
            where N : Node
        {
            //Get the root node.
            var _root =
                ((N)Activator.CreateInstance(typeof(N), @this, string.IsNullOrWhiteSpace(@this.BeginFormat.ToString()) ? content : @this.InnerText(content)))
                //Iterate through the current Node.Tag's Child Tags
                .GetChildNodes<T, N>();
            return _root;
        }
    }
}
