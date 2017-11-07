using System.Collections.Generic;
using System.Linq;

namespace Leaf
{
    public interface INode
    {
        Tag Tag { get; }
        string InnerText { get; }
        List<INode> Children { get; }
    }

    public class Node : INode
    {
        public Tag Tag { get; }
        public string InnerText { get; }
        public List<INode> Children { get; internal set; }

        public Node() { }
        public Node(Tag tag, string innerText)
        {
            Tag = tag.Copy();
            InnerText = innerText;
            Children = new List<INode>();
        }
        public virtual Node GetAttributes() => this;

        public override string ToString() => $"{{{Tag.Name} [Children: {Children.Count}]}}";
    }
    public class Node<T> : Node where T : Tag, new()
    {
        public Node(string innerText) : base(new T(), innerText)
        {
        }
    }

    public static partial class Extensions
    {
        public static string Parse(this Node @this)
        {
            return @this.ToString();
        }
        /// <summary>Append a child Node in the hierarchy schema. Return the parent.</summary>
        public static T AppendChild<T>(this T @this, INode child) where T : INode
        {
            @this.Children.Add(child);
            return @this;
        }
        public static IEnumerable<INode> NodesByTagType<T>(this INode @this)
            => @this.Children.Where(x => x.Tag.GetType() == typeof(T));
    }
}
