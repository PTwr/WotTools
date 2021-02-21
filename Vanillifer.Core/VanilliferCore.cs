using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Vanillifer.Core.Skins;

namespace Vanillifer.Core
{
    public class VanilliferCore
    {
        public static string DefaultGamePath = @"C:\games\World_of_Tanks";
        private readonly string gamePath;
        private readonly string version;
        public readonly SkinsHelper SkinList;

        public VanilliferCore(string gamePath)
        {
            if (!CheckGamePath(gamePath))
            {
                throw new Exception($"Provided path '{gamePath} does not look like valid WoT game directory");
            }

            this.gamePath = gamePath;
            this.version = GetGameVersion(gamePath);

            this.SkinList = new Skins.SkinsHelper(gamePath);
        }

        public static string GetGameVersion(string gamePath)
        {
            var versionXMLpath = Path.Combine(gamePath, "version.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(versionXMLpath);
            XmlNode node = doc.DocumentElement.SelectSingleNode("/version.xml/version");
            if (node == null)
            {
                throw new Exception($"Could not find version node in version.xml");
            }
            Regex regex = new Regex(@"\d+\.\d+\.\d+\.\d+");
            var match = regex.Matches(node.InnerText);
            if (match.Count != 0)
            {
                throw new Exception($"Could not parse game version from '{node.InnerText}'");
            }
            var version = match[0].Value;
            return version;
        }

        public static bool CheckGamePath(string gamePath)
        {
            return
                File.Exists(Path.Combine(gamePath, "WorldOfTanks.exe"))
                &&
                File.Exists(Path.Combine(gamePath, "WoTLauncher.exe"))
                &&
                File.Exists(Path.Combine(gamePath, "version.xml"))
                &&
                File.Exists(Path.Combine(gamePath, "paths.xml"))
                &&
                Directory.Exists(Path.Combine(gamePath, "res", "packages"))
                ;
        }
    }
}
