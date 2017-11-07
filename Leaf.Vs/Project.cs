using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Xml;

namespace Leaf.Vs
{
    public class Project
    {
        public XDocument Document { get; }
        public string Path { get; }
        public string ProjectGuid => this.ProjectGuid();
        public string ProjectTypeGuid => this.ProjectTypeGuid();
        public string ProjectName => this.ProjectName();

        public Project(string path)
        {
            Path = path;
            Document = XDocument.Load(path);
        }
    }

    public static partial class Extensions
    {
        public static XNamespace Namespace(this Project @this) => @this.Document.Root.GetDefaultNamespace();
        public static string NamespaceString(this Project @this) => $"{{{@this.Namespace()}}}".EscapeCurlyBraces();
        public static IEnumerable<XElement> GetElements(this Project @this, string name)
            => @this.Document.Elements().DescendantsAndSelf($"{@this.NamespaceString()}{name}");
        public static string ProjectGuid(this Project @this)
            => @this.GetElements("ProjectGuid").FirstOrDefault()?.Value;
        public static string ProjectTypeGuid(this Project @this)
        {
            var result = @this.GetElements("ProjectTypeGuid").FirstOrDefault()?.Value;
            if (string.IsNullOrWhiteSpace(result))
            {
                var outputType = @this.OutputType();
                if (outputType == "Library")
                {
                    if (@this.GetImports().Select(x => x.Attribute("Project")).Any(x => x.Value.Contains("CSharp")))
                    {
                        result = Constants.ProjectTypeGuids.CSharp;
                    }
                }
            }
            return result;     
        }
        public static string ProjectName(this Project @this)
            => @this.GetElements("AssemblyName").FirstOrDefault()?.Value;
        public static string OutputType(this Project @this)
            => @this.GetElements("OutputType").FirstOrDefault()?.Value;
        public static IEnumerable<XElement> GetImports(this Project @this)
            => @this.GetElements("Import");
        public static Node ToNode(this Project @this)
        {
            var result = new Nodes.Solution.Project("");
            result.ProjectGuid = @this.ProjectGuid;
            result.ProjectName = @this.ProjectName;
            result.Path = @this.Path;
            result.ProjectTypeGuid = @this.ProjectTypeGuid;
            return result;
        }
    }
}
