using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ptwr.PackedXml
{
    public class Reader
    {
        public static string DecodePackedFile(BinaryReader reader, string filename)
        {
            XmlDocument xDoc = new XmlDocument();

            var sb = reader.ReadSByte();

            var PS = new Packed_Section();

            var dictionary = PS.readDictionary(reader);

            if (Char.IsNumber(filename.First()))
            {
                filename = "bad_" + filename;
            }

            var xmlroot = xDoc.CreateNode(XmlNodeType.Element, filename, "");
            //pos202
            PS.readElement(reader, xmlroot, xDoc, dictionary);
            var xml_string = xmlroot.OuterXml;
            xml_string = NXMLFormatter.Formatter.Format(xml_string);

            xDoc.LoadXml(xml_string);
            var newDict = GetXmlDict(xDoc);

            var x = Enumerable.SequenceEqual(dictionary, newDict);

            return xml_string;
        }

        public static List<string> GetXmlDict(XmlNode element)
        {
            if (element.NodeType != XmlNodeType.Element)
            {
                return new List<string>();
            }

            List<string> result = new List<string>();
            if (element.Name == "xmlref")
            {
                result.Add("xmlns:xmlref");
                //Debugger.Break();
            }
            else
            {
                result.Add(element.Name);
            }
            foreach (XmlNode node in element.ChildNodes)
            {
                result.AddRange(GetXmlDict(node));
            }
            return result;
        }
        public static List<string> GetXmlDict(XmlDocument doc)
        {
            List<string> result = new List<string>();
            foreach (XmlNode node in doc.FirstChild.ChildNodes)
            {
                result.AddRange(GetXmlDict(node));
            }

            result = result.Distinct().OrderBy(i => i).ToList();

            return result;
        }
        public static void EncodePackedFile(string path, string xml)
        {
            var PS = new Packed_Section();

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);

            File.Delete(path);
            var f = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(f);

            //header
            writer.Write(Packed_Section.Packed_Header);
            writer.Write((sbyte)0);

            //dictionary
            var newDict = GetXmlDict(xDoc);
            PS.writeDictionary(writer, newDict);

            //records
            PS.WriteElement(writer, xDoc.FirstChild, xDoc, newDict);

            f.Flush();
            f.Close();
        }
    }
}
