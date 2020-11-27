using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using WotTools;

namespace WotToolsCLI
{
    class Program
    {
        static int Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                //args = new string[] {
                //    "extract",
                //    "--input",@"C:\games\World_of_Tanks\res\packages\scripts.pkg",
                //    "--file", @"scripts/item_defs/customization/paints/list.xml" };
                //args = new string[] {
                //    "xmldecode",
                //    "--input",@"scripts/item_defs/customization/paints/list.xml"};
                //args = new string[] { "--version" };
                //args = new string[] { "--help", "wotmod" };
                //args = new string[] { "--help", "extract" };
                //args = new string[] {
                //"wotmod",
                //"--input",@"scripts",
                //"--output",@"test.wotmod"};
                args = new string[] {
                    "extract",
                    "--input",@"C:\games\World_of_Tanks\res\packages\scripts.pkg",
                    "--file", @"scripts/item_defs/customization/camouflages/list.xml",
                    "--decode" };
            }
            var exitCode = CommandLine.Parser.Default.ParseArguments<ExtractOptions, XmlDecodeOptions, XmlEncodeOptions, WotModOptions>(args)
                .MapResult(
                (ExtractOptions opts) => Extract(opts),
                (XmlDecodeOptions opts) => XmlDecode(opts),
                (XmlEncodeOptions opts) => XmlEncode(opts),
                (WotModOptions opts) => WotMod(opts),
                errs => 1
            );

            if (Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.WriteLine($"Exit code: {exitCode}");
                Console.WriteLine("Prease any key to continue");
                Console.ReadKey();
            }

            return exitCode;
        }

        static int Extract(ExtractOptions opts)
        {
            if (string.IsNullOrWhiteSpace(opts.Output))
            {
                opts.Output = opts.File;
            }

            return WotPkg.TryExtractFile(opts.Input, opts.File, (Stream stream) =>
            {
                Directory.CreateDirectory(Path.GetDirectoryName(opts.Output));

                if (opts.Decode)
                {
                    if (WotXml.TryDecodeXml(opts.File, stream, out var decodedXml))
                    {
                        File.WriteAllText(opts.Output, decodedXml);
                    }
                }
                else
                {
                    using (var fileStream = File.OpenWrite(opts.Output))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }) ? 0 : 1;
        }
        static int XmlDecode(XmlDecodeOptions opts)
        {
            if (string.IsNullOrWhiteSpace(opts.Output))
            {
                opts.Output = opts.Input;
            }

            if (WotXml.TryDecodeXml(opts.Input, out var decodedXml))
            {
                File.WriteAllText(opts.Output, decodedXml);
                return 0;
            }
            else
            {
                throw new Exception("Failed to decode xml");
            }

        }
        static int XmlEncode(XmlEncodeOptions opts)
        {
            if (string.IsNullOrWhiteSpace(opts.Output))
            {
                opts.Output = opts.Input;
            }

            if (WotXml.TryEncodeXml(opts.Input, out var decodedXml))
            {
                File.WriteAllText(opts.Output, decodedXml);
                return 0;
            }
            else
            {
                throw new Exception("Failed to decode xml");
            }

        }
        static int WotMod(WotModOptions opts)
        {
            if (string.IsNullOrWhiteSpace(opts.Output))
            {
                opts.Output = "mod.wotmod";
            }

            if (!WotTools.WotMod.TryCreateWotMod(opts.Output, opts.Input))
            {
                throw new Exception("Failed to create wotmod");
            }
            return 0;
        }
    }
}
