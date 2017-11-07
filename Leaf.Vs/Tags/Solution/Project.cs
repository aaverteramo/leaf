using static Leaf.Vs.Constants;

namespace Leaf.Vs.Tags.Solution
{
    //Project("{GUID}")
    //EndProject
    public class Project : Tag<Nodes.Solution.Project>
    {
        public Project() : base("Project", $"Project{_Regex.Project.ToString()}", $"EndProject")
        {
            this.AddProperty("ProjectTypeGuid")
                .AddProperty("ProjectName")
                .AddProperty("Path")
                .AddProperty("ProjectGuid");
        }
    }
}
