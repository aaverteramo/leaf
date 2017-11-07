using System;

namespace Leaf.Vs.Tags.Solution
{
    //Microsoft Visual Studio Solution File, Format Version 12.00
    //# Visual Studio 14
    //VisualStudioVersion = 14.0.25420.1
    //MinimumVisualStudioVersion = 10.0.40219.1
    public class Header : Tag<Nodes.Solution.Header>
    {
        public Header()
            : base("Microsoft Visual Studio Solution File", $"{Environment.NewLine}Microsoft Visual Studio Solution File", "Project")
        {
            this.AddProperty("FormatVersion")
                .AddProperty("VisualStudioVersion")
                .AddProperty("MinimumVisualStudioVersion");
        }
    }
}
