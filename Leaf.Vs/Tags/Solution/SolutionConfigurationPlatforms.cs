using Leaf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf.Vs.Tags.Solution
{
    //GlobalSection(SolutionConfigurationPlatforms) = preSolution
    //EndGlobalSection
    public class SolutionConfigurationPlatforms : Tag<Nodes.Solution.SolutionConfigurationPlatforms>
    {
        public SolutionConfigurationPlatforms()
            : base("SolutionConfigurationPlatforms", "GlobalSection(SolutionConfigurationPlatforms)", "GloablSectionEnd")
        {
        }
    }
}
