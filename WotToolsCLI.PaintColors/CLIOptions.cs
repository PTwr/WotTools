using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WotTools.CLI;

namespace WotToolsCLI.PaintColors
{
    [Verb("color", HelpText = "Sets color value in paints list")]
    public class SetColorOptions : IOOptions
    {
        [Option(shortName: 'i', longName: "input", HelpText = "Path to list.xml file", Required = true)]
        public string Input { get; set; }

        [Option(shortName: 'o', longName: "output", HelpText = "Path to which modified file will be saved")]
        public string Output { get; set; }

        [Option(shortName: 'c', longName: "color", HelpText = "RGB (rrr ggg bbb) or RGBA (rrr ggg bbb aaa) color", Required = true)]
        public string Color { get; set; }

        [Option(shortName: 'g', longName: "group", Default = "*", HelpText = "Filters colors by groups")]
        public string GroupName { get; set; }
        [Option(shortName: 'u', longName: "userstring", Default = "*", HelpText = "Filters color by user string")]
        public string ColorUserString { get; set; }
        [Option(shortName: 'i', longName: "colorid", Default = "*", HelpText = "Filters colors by id")]
        public string ColorId { get; set; }
    }

    [Verb("patch", HelpText = "Patches list.xml colors with existing one")]
    public class PatchOptions
    {
        [Option(shortName: 'i', longName: "input", HelpText = "Path to list.xml file", Required = true)]
        public string Input { get; set; }

        [Option(shortName: 'o', longName: "output", HelpText = "Path to which modified file will be saved")]
        public string Output { get; set; }

        [Option(shortName: 'f', longName: "file", HelpText = "File to patch with", Required = true)]
        public string File { get; set; }
    }
}
