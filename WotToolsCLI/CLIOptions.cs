using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WotTools.CLI;

namespace WotToolsCLI
{
    [Verb("extract", HelpText = "Extracts file from .pkg archive")]
    public class ExtractOptions : IOOptions
    {
        [Option(shortName: 'i', longName: "input", HelpText = "Package file path", Required = true)]
        public string Input { get; set; }

        [Option(shortName: 'o', longName: "output", HelpText = "Path to which extracted file will be saved")]
        public string Output { get; set; }

        [Option(shortName: 'f', longName: "file", HelpText = "File to extract. Path relative to archive root", Required = true)]
        public string File { get; set; }

        [Option(shortName:'d',longName:"decode", Default = false, HelpText = "Automatically decodes xml files")]
        public bool Decode { get; set; }
    }

    [Verb("xmldecode", HelpText = "Handless WoT binary encoded xml files")]
    public class XmlDecodeOptions : IOOptions
    {
        [Option(shortName: 'i', longName: "input", HelpText = "Encoded xml file", Required = true)]
        public string Input { get; set; }

        [Option(shortName: 'o', longName: "output", HelpText = "Path to which extracted file will be saved")]
        public string Output { get; set; }
    }

    [Verb("wotmod", HelpText = "Creates WotMod packages")]
    public class WotModOptions : IOOptions
    {
        [Option(shortName: 'i', longName: "input", HelpText = "Directory to package", Required = true)]
        public string Input { get; set; }

        [Option(shortName: 'o', longName: "output", HelpText = "Path to which created WotMod file will be saved")]
        public string Output { get; set; }
    }
}
