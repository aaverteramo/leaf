using Leaf;
using Leaf.Vs.Tags;
using System;
using System.Text.RegularExpressions;

namespace Leaf.Vs
{
    public static class Constants
    {
        internal static class _Regex
        {
            internal static readonly Regex GuidChars = new Regex("[0-9aA-zZ]");
            internal static readonly Regex Guid = new Regex($@"{{({GuidChars}{{8}}-{GuidChars}{{4}}-{GuidChars}{{4}}-{GuidChars}{{4}}-{GuidChars}{{12}})}}".EscapeCurlyBraces());
            internal static readonly Regex GuidString = new Regex($@"""{{{Guid}}}""".EscapeCurlyBraces());
            internal static readonly Regex Project = new Regex($@"\({GuidString}\)");
        }
        internal static class _Tags
        {
            internal static readonly Tag<Node> Root = new Tag<Node>("Root", "", "");
            internal static readonly Tags.Solution.Global Global = new Tags.Solution.Global();
            internal static readonly Tags.Solution.Project Project = new Tags.Solution.Project();
            internal static readonly Tags.Solution.ProjectConfigurationPlatforms ProjectConfigurationPlatforms = new Tags.Solution.ProjectConfigurationPlatforms();
            internal static readonly Tags.Solution.SolutionConfigurationPlatforms SolutionConfigurationPlatforms = new Tags.Solution.SolutionConfigurationPlatforms();
        }
        internal static class _Nodes
        {
            internal static readonly Node<Tag> Root = new Node<Tag>(string.Empty);
            internal static readonly Nodes.Solution.Global Global = new Nodes.Solution.Global(string.Empty);
            internal static readonly Nodes.Solution.Project Project = new Nodes.Solution.Project(string.Empty);
            internal static readonly Nodes.Solution.ProjectConfigurationPlatforms ProjectConfigurationPlatforms = new Nodes.Solution.ProjectConfigurationPlatforms(string.Empty);
            internal static readonly Nodes.Solution.SolutionConfigurationPlatforms SolutionConfigurationPlatforms = new Nodes.Solution.SolutionConfigurationPlatforms(string.Empty);
        }

        internal static class ProjectTypeGuids
        {
            internal static readonly string ASPNET5 = "{8BB2217D-0F2D-49D1-97BC-3654ED321F3B}";
            internal static readonly string ASPNETMVC1 = "{603C0E0B-DB56-11DC-BE95-000D561079B0}";
            internal static readonly string ASPNETMVC2 = "{F85E285D-A4E0-4152-9332-AB1D724D3325}";
            internal static readonly string ASPNETMVC3 = "{E53F8FEA-EAE0-44A6-8774-FFD645390401}";
            internal static readonly string ASPNETMVC4 = "{E3E379DF-F4C6-4180-9B81-6769533ABE47}";
            internal static readonly string ASPNETMVC5 = "{349C5851-65DF-11DA-9384-00065B846F21}";
            internal static readonly string CSharp = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";
            internal static readonly string CPlusPlus = "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}";
            internal static readonly string Database = "{A9ACE9BB-CECE-4E62-9AA4-C7E7C5BD2124}";
            internal static readonly string Databaseotherprojecttypes = "{4F174C21-8C12-11D0-8340-0000F80270F8}";
            internal static readonly string DeploymentCab = "{3EA9E505-35AC-4774-B492-AD1749C4943A}";
            internal static readonly string DeploymentMergeModule = "{06A35CCD-C46D-44D5-987B-CF40FF872267}";
            internal static readonly string DeploymentSetup = "{978C614F-708E-4E1A-B201-565925725DBA}";
            internal static readonly string DeploymentSmartDeviceCab = "{AB322303-2255-48EF-A496-5904EB18DA55}";
            internal static readonly string DistributedSystem = "{F135691A-BF7E-435D-8960-F99683D2D49C}";
            internal static readonly string Dynamics2012AXCSharpinAOT = "{BF6F8E12-879D-49E7-ADF0-5503146B24B8}";
            internal static readonly string FSharp = "{F2A71F9B-5D33-465A-A702-920D77279786}";
            internal static readonly string JSharp = "{E6FDF86B-F3D1-11D4-8576-0002A516ECE8}";
            internal static readonly string Legacy2003SmartDeviceCSharp = "{20D4826A-C6FA-45DB-90F4-C717570B9F32}";
            internal static readonly string Legacy2003SmartDeviceVBNET = "{CB4CE8C6-1BDB-4DC7-A4D3-65A1999772F8}";
            internal static readonly string MicroFramework = "{b69e3092-b931-443c-abe7-7e7b65f2a37f}";
            internal static readonly string Model_View_Controllerv2MVC2 = "{F85E285D-A4E0-4152-9332-AB1D724D3325}";
            internal static readonly string Model_View_Controllerv3MVC3 = "{E53F8FEA-EAE0-44A6-8774-FFD645390401}";
            internal static readonly string Model_View_Controllerv4MVC4 = "{E3E379DF-F4C6-4180-9B81-6769533ABE47}";
            internal static readonly string Model_View_Controllerv5MVC5 = "{349C5851-65DF-11DA-9384-00065B846F21}";
            internal static readonly string MonoforAndroid = "{EFBA0AD7-5A72-4C68-AF49-83D382785DCF}";
            internal static readonly string MonoTouch = "{6BC8ED88-2882-458C-8E55-DFD12B67127B}";
            internal static readonly string MonoTouchBinding = "{F5B4F3BC-B597-4E2B-B552-EF5D8A32436F}";
            internal static readonly string PortableClassLibrary = "{786C830F-07A1-408B-BD7F-6EE04809D6DB}";
            internal static readonly string ProjectFolders = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
            internal static readonly string SharePointCSharp = "{593B0543-81F6-4436-BA1E-4747859CAAE2}";
            internal static readonly string SharePointVBNET = "{EC05E597-79D4-47f3-ADA0-324C4F7C7484}";
            internal static readonly string SharePointWorkflow = "{F8810EC1-6754-47FC-A15F-DFABD2E3FA90}";
            internal static readonly string Silverlight = "{A1591282-1198-4647-A2B1-27E5FF5F6F3B}";
            internal static readonly string SmartDeviceCSharp = "{4D628B5B-2FBC-4AA6-8C16-197242AEB884}";
            internal static readonly string SmartDeviceVBNET = "{68B1623D-7FB9-47D8-8664-7ECEA3297D4F}";
            internal static readonly string SolutionFolder = "{2150E333-8FDC-42A3-9474-1A3956D46DE8}";
            internal static readonly string Test = "{3AC096D0-A1C2-E12C-1390-A8335801FDAB}";
            internal static readonly string UniversalWindowsClassLibrary = "{A5A43C5B-DE2A-4C0C-9213-0A381AF9435A}";
            internal static readonly string VBNET = "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}";
            internal static readonly string VisualDatabaseTools = "{C252FEB5-A946-4202-B1D4-9916A0590387}";
            internal static readonly string VisualStudio2015InstallerProjectExtension = "{54435603-DBB4-11D2-8724-00A0C9A8B90C}";
            internal static readonly string VisualStudioToolsforApplicationsVSTA = "{A860303F-1F3F-4691-B57E-529FC101A107}";
            internal static readonly string VisualStudioToolsforOfficeVSTO = "{BAA0C2D2-18E2-41B9-852F-F413020CAA33}";
            internal static readonly string WebApplication = "{349C5851-65DF-11DA-9384-00065B846F21}";
            internal static readonly string WebSite = "{E24C65DC-7377-472B-9ABA-BC803B73C61A}";
            internal static readonly string WindowsCSharp = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";
            internal static readonly string WindowsVBNET = "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}";
            internal static readonly string WindowsVisualCPlusPlus = "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}";
            internal static readonly string WindowsCommunicationFoundationWCF = "{3D9AD99F-2412-4246-B90B-4EAA41C64699}";
            internal static readonly string WindowsPhone8_81Blank_Hub_WebviewApp = "{76F1466A-8B6D-4E39-A767-685A06062A39}";
            internal static readonly string WindowsPhone8_81AppCSharp = "{C089C8C0-30E0-4E22-80C0-CE093F111A43}";
            internal static readonly string WindowsPhone8_81AppVBNET = "{DB03555F-0C8B-43BE-9FF9-57896B3C5E56}";
            internal static readonly string WindowsPresentationFoundationWPF = "{60DC8134-EBA5-43B8-BCC9-BB4BC16C2548}";
            internal static readonly string WindowsStoreMetroApps_Components = "{BC8A1FFA-BEE3-4634-8014-F334798102B3}";
            internal static readonly string WorkflowCSharp = "{14822709-B5A1-4724-98CA-57A101D1B079}";
            internal static readonly string WorkflowVBNET = "{D59BE175-2ED0-4C54-BE3D-CDAA9F3214C8}";
            internal static readonly string WorkflowFoundation = "{32F31D43-81CC-4C15-9DE6-3FC5453562B6}";
            internal static readonly string XamarinAndroid = "{EFBA0AD7-5A72-4C68-AF49-83D382785DCF}";
            internal static readonly string XamariniOS = "{6BC8ED88-2882-458C-8E55-DFD12B67127B}";
            internal static readonly string XNAWindows = "{6D335F3A-9D43-41b4-9D22-F6F17C4BE596}";
            internal static readonly string XNAXBox = "{2DF5C3F4-5A5F-47a9-8E94-23B4456F55E2}";
            internal static readonly string XNAZune = "{D399B71A-8929-442a-A9AC-8BEC78BB2433}";
        }
    }
}
