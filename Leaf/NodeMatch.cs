using System.Text.RegularExpressions;

namespace Leaf
{
    internal class NodeMatch
    {
        internal bool Begin { get; }
        internal Match Match { get; }
        internal int Nest { get; set; }
        public NodeMatch(bool begin, Match match)
        {
            Begin = begin;
            Match = match;
        }
        public override string ToString() => $"{{Begin:{Begin}, Index:{Match.Index}, Nest:{Nest}}}".EscapeCurlyBraces();
    }
}
