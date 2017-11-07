using Leaf;
using System;

namespace Leaf.Vs.Tags.Solution
{
    //Global
    //EndGlobal
    public class Global : Tag<Nodes.Solution.Global>
    {
        public Global()
            : base(
                  "Global",
                  $"{Environment.NewLine}Global{Environment.NewLine}".EscapeCurlyBraces(),
                  $"{Environment.NewLine}EndGlobal{Environment.NewLine}")
        {
        }
    }
}
