namespace Leaf.Vs.Nodes.Solution
{
    //Project("{GUID}")
    //EndProject
    public class Project : Node<Tags.Solution.Project>
    {
        public string ProjectTypeGuid
        {
            get { return Tag.GetProperty("ProjectTypeGuid"); }
            set { Tag.SetProperty("ProjectTypeGuid", value); }
        }
        public string ProjectName
        {
            get { return Tag.GetProperty("ProjectName"); }
            set { Tag.SetProperty("ProjectName", value); }
        }
        public string Path
        {
            get { return Tag.GetProperty("Path"); }
            set { Tag.SetProperty("Path", value); }
        }
        public string ProjectGuid
        {
            get { return Tag.GetProperty("ProjectGuid"); }
            set { Tag.SetProperty("ProjectGuid", value); }
        }
        public Project(string innerText) : base(innerText)
        {
        }

        public override Node GetAttributes()
        {
            //ProjectName
            var b = "= \"";
            var e = "\",";
            var ixb = InnerText.IndexOf(b) + b.Length;
            var value = InnerText.Substring(ixb);
            ProjectName = value.Substring(0, value.IndexOf(e));
            //Path
            b = ", \"";
            ixb = value.IndexOf(b) + b.Length;
            value = value.Substring(ixb);
            Path = value.Substring(0, value.IndexOf(e));
            //ProjectGuid
            e = "\"";
            ixb = value.IndexOf(b) + b.Length;
            value = value.Substring(ixb);
            ProjectGuid = value.Substring(0, value.IndexOf(e));
            return this;
        }
    }

    public static partial class Extensions
    {
        public static string Format(this Project @this)
            => $@"
Project(""{@this.ProjectTypeGuid}"") = ""{@this.ProjectName}"", ""{@this.Path}"", ""{@this.ProjectGuid}""
EndProject";
    }
}
