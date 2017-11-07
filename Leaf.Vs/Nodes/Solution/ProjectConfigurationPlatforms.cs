namespace Leaf.Vs.Nodes.Solution
{
    //GlobalSection(ProjectConfigurationPlatforms) = postSolution
    //EndGlobalSection
    public class ProjectConfigurationPlatforms : Node<Tags.Solution.ProjectConfigurationPlatforms>
    {
        public ProjectConfigurationPlatforms(string innerText) : base(innerText)
        {
        }
    }
    public static partial class Extensions
    {
        public static string Format(this ProjectConfigurationPlatforms @this)
            => $"{@this.Tag.BeginFormat.ToString()} = postSolution";
        //TODO: add 
    }
}
