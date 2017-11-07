namespace Leaf.Vs.Nodes.Solution
{
    //Microsoft Visual Studio Solution File, Format Version 12.00
    //# Visual Studio 14
    //VisualStudioVersion = 14.0.25420.1
    //MinimumVisualStudioVersion = 10.0.40219.1
    public class Header : Node<Tags.Solution.Header>
    {
        public string FormatVersion
        {
            get { return Tag.GetProperty("FormatVersion"); }
            set { Tag.SetProperty("FormatVersion", value); }
        }
        public string VisualStudioVersion
        {
            get { return Tag.GetProperty("VisualStudioVersion"); }
            set { Tag.SetProperty("VisualStudioVersion", value); }
        }
        public string MinimumVisualStudioVersion
        {
            get { return Tag.GetProperty("MinimumVisualStudioVersion"); }
            set { Tag.SetProperty("MinimumVisualStudioVersion", value); }
        }

        public Header(string innerText) : base(innerText)
        {
        }
    }

    public static partial class Extensions
    {
        public static string Format(this Header @this)
            => $@"
//Microsoft Visual Studio Solution File, Format Version {@this.FormatVersion}
//# Visual Studio 14
//VisualStudioVersion = {@this.VisualStudioVersion}
//MinimumVisualStudioVersion = {@this.MinimumVisualStudioVersion}";
    }
}
