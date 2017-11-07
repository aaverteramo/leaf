using System.IO;

namespace Leaf.Vs
{
    public class Solution
    {
        public static readonly Tag<Node> Schema =
            Constants._Tags.Root
                .AppendChild(Constants._Tags.Project)
                .AppendChild(Constants._Tags.Global
                    .AppendChild(Constants._Tags.SolutionConfigurationPlatforms)
                    .AppendChild(Constants._Tags.ProjectConfigurationPlatforms)
                );
        public static readonly Node NSchema =
            Constants._Nodes.Root
                .AppendChild(Constants._Nodes.Project)
                .AppendChild(Constants._Nodes.Global
                    .AppendChild(Constants._Nodes.SolutionConfigurationPlatforms)
                    .AppendChild(Constants._Nodes.ProjectConfigurationPlatforms)
                );

        internal FileInfo _file { get; }
        internal string _data { get; }
        public Solution(string path, bool create = false)
        {
            _file = new FileInfo(path);
            if (!_file.Exists)
                this.Create();
            using (var s = _file.OpenText())
                _data = s.ReadToEnd();
        }
    }

    public static partial class Extensions
    {
        public static Solution Create(this Solution @this)
        {
            if (!@this._file.Exists)
                @this._file.Create().Close();
            @this._file.Refresh();
            return @this;
        }
        public static Node ToNode(this Solution @this)
            => Solution.Schema.Parse<Tag<Node>, Node>(@this._data);

        //public static string Format(this Solution @this)
        //    => @this.ToNode().
    }
}
