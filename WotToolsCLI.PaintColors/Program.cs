using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using WotTools;
using WildcardMatch;
using System.IO;

namespace WotToolsCLI.PaintColors
{
    class Program
    {
        static int Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                args = new string[] {
                "patch",
                "--input",@"scripts\item_defs\customization\paints\list.xml",
                "--file",@"C:\games\World_of_Tanks\mods\no colors\list.xml"};
            }
            var exitCode = CommandLine.Parser.Default.ParseArguments<SetColorOptions, PatchOptions>(args)
                .MapResult(
                (SetColorOptions opts) => SetColor(opts),
                (PatchOptions opts) => Patch(opts),
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

        static int SetColor(SetColorOptions opts)
        {
            if (string.IsNullOrWhiteSpace(opts.Output))
            {
                opts.Output = opts.Input;
            }

            if (WotPaints.TryLoadPaints(opts.Input, out var xmlModel))
            {
                var colors = xmlModel
                    .itemGroup
                    .SelectMany(i => i.paint, (group, paint) => new { group, paint });

                colors = colors
                    .Where(i => opts.GroupName.WildcardMatch(i.group.name, ignoreCase: true))
                    .Where(i => opts.ColorUserString.WildcardMatch(i.paint.userString, ignoreCase: true))
                    .Where(i => opts.ColorId.WildcardMatch(i.paint.id.ToString(), ignoreCase: true));

                colors
                    .ToList()
                    .ForEach(i => i.paint.color = opts.Color);

                var xml = WotPaints.SerializeToXml(xmlModel);

                File.WriteAllText(opts.Output, xml);

                return 0;
            }
            else
            {
                throw new Exception("Failed to load paints definitions");
            }
        }

        static int Patch(PatchOptions opts)
        {
            if (string.IsNullOrWhiteSpace(opts.Output))
            {
                opts.Output = opts.Input;
            }
            if (!WotPaints.TryLoadPaints(opts.Input, out var xmlModel))
            {
                throw new Exception("Failed to load paints definitions");
            }
            if (!WotPaints.TryLoadPaints(opts.File, out var xmlModelPatch))
            {
                throw new Exception("Failed to load paints definitions patch");
            }

            var paints = xmlModel
                .itemGroup
                .SelectMany(i => i.paint);
            var patchPaints = xmlModelPatch
                .itemGroup
                .SelectMany(i => i.paint)
                .ToDictionary(i => i.id, i => i);

            foreach (var paint in paints)
            {
                if (patchPaints.TryGetValue(paint.id, out var patchPaint))
                {
                    paint.color = patchPaint.color;
                    paint.gloss = patchPaint.gloss;
                    paint.metallic = patchPaint.metallic;
                }
            }

            var xml = WotPaints.SerializeToXml(xmlModel);

            File.WriteAllText(opts.Output, xml);

            return 0;
        }
    }
}
