using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WotTools;

namespace Vanillifer.Core.Skins
{
    public class SkinsHelper
    {
        private readonly string gamePath;
        private const string StylesListXmlPath = "scripts/item_defs/customization/styles/list.xml";

        private string DecodedXml = null;
        private XmlDocument ListXMLDocument = new XmlDocument();

        public SkinsHelper(string gamePath)
        {
            this.gamePath = gamePath;
        }

        public string ToXml()
        {
            return ListXMLDocument.OuterXml;
        }

        public List<Skin> GetSkins()
        {
            List<Skin> result = new List<Skin>();

            if (!WotPkg.TryExtractFile(Path.Combine(gamePath,
                @"res\packages\scripts.pkg"),
                StylesListXmlPath,
                FetchDecodedXml))
            {
                throw new Exception("Failed to extract styles list from pkg");
            }

            Dictionary<string, Image> images = new Dictionary<string, Image>(StringComparer.InvariantCultureIgnoreCase);
            WotPkg.TryExtractDirectory(
                Path.Combine(gamePath, @"res\packages\gui-part1.pkg"),
                "gui/maps/vehicles/styles/",
                (stream, entry) =>
                {
                    if (entry.Name.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var img = Image.FromStream(stream);
                        images[entry.FullName] = img;
                    }
                });
            WotPkg.TryExtractDirectory(
                Path.Combine(gamePath, @"res\packages\gui-part2.pkg"),
                "gui/maps/vehicles/styles/",
                (stream, entry) =>
                {
                    if (entry.Name.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var img = Image.FromStream(stream);
                        images[entry.FullName] = img;
                    }
                });


            var xmlrefNode = ListXMLDocument.DocumentElement.SelectSingleNode("/list.xml/xmlref");
            if (xmlrefNode != null)
            {
                ListXMLDocument.DocumentElement.RemoveChild(xmlrefNode);
            }

            int n = 0;
            foreach (XmlNode itemGroup in ListXMLDocument.DocumentElement.SelectNodes("/list.xml/itemGroup/style"))
            {
                n++;
                try
                {
                    var skin = new Skin()
                    {
                        Id = int.Parse(itemGroup.SelectSingleNode("id").InnerText),
                        Texture = itemGroup.SelectSingleNode("texture").InnerText,
                        Name = itemGroup.SelectSingleNode("userString").InnerText, //TODO load translations?
                    };

                    //some special style have no pictures
                    if (!string.IsNullOrWhiteSpace(skin.Texture))
                    {
                        //if (!TryLoadSkinPicture(skin.Texture, out var picture))
                        //{
                        //    throw new Exception($"Failed to load picture '{skin.Texture}'");
                        //}
                        //skin.Picture = picture;
                        if (images.TryGetValue(skin.Texture, out var img))
                        {
                            skin.Picture = img;
                        }
                    }

                    result.Add(skin);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to parse itemGroup #{n}", ex);
                }
            }

            foreach (var unusedImg in images.Where(i => !result.Any(r => r.Picture == i.Value)))
            {
                unusedImg.Value.Dispose();
            }
            return result;
        }

        public void RemoveSkin(Skin skin)
        {
            var parentNode = ListXMLDocument.SelectSingleNode($"/list.xml/itemGroup/style[id = '{skin.Id}']");
            var noSkin = CreateEmptySkinNode();
            var skinNode = parentNode.SelectSingleNode("outfits");
            parentNode.ReplaceChild(noSkin, skinNode);

            var modelset = parentNode.SelectSingleNode("modelsSet");
            if (modelset != null)
            {
                var set = modelset.InnerText;
                parentNode.RemoveChild(modelset);
            }
        }

        private static string EmptySkinXML =
@"        <outfit>
          <season>	ALL	</season>
          <camouflages>
            <item>
              <id>	1	</id>
              <appliedTo>	4368	</appliedTo>
              <patternSize>	1	</patternSize>
              <palette>	0	</palette>
            </item>
          </camouflages>
        </outfit>";
        private XmlNode CreateEmptySkinNode()
        {
            var element = ListXMLDocument.CreateElement("outfits");
            element.InnerXml = EmptySkinXML;
            return element;
        }

        private bool TryLoadSkinPicture(string path, out Image picture)
        {
            Image img = null;
            Action<Stream> getStream = (Stream stream) =>
            {
                img = Image.FromStream(stream);
            };
            if (WotPkg.TryExtractFile(Path.Combine(gamePath,
                @"res\packages\gui-part1.pkg"),
                path,
                getStream,
                verbose: false) && img != null)
            {
                picture = img;
                return true;
            }
            if (WotPkg.TryExtractFile(Path.Combine(gamePath,
                @"res\packages\gui-part2.pkg"),
                path,
                getStream,
                verbose: false) && img != null)
            {
                picture = img;
                return true;
            }

            picture = null;
            return false;
        }

        private void FetchDecodedXml(Stream stream)
        {
            if (!WotXml.TryDecodeXml(StylesListXmlPath, stream, out DecodedXml))
            {
                throw new Exception("Failed to decode styles list");
            }

            ListXMLDocument.LoadXml(DecodedXml);
        }
    }

    public class Skin
    {
        public int Id { get; set; }
        public string Texture { get; set; }
        public Image Picture { get; set; }
        public string Name { get; set; }
    }
}
