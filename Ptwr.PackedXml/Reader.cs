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
        public static string DecodePackedFile(BinaryReader reader, string rootName)
        {
            XmlDocument xDoc = new XmlDocument();

            var sb = reader.ReadSByte();

            var PS = new Packed_Section();

            var dictionary = PS.readDictionary(reader);

            var xmlroot = xDoc.CreateNode(XmlNodeType.Element, rootName, "");
            //pos202
            PS.readElement(reader, xmlroot, xDoc, dictionary);
            var xml_string = xmlroot.OuterXml;
            xml_string = NXMLFormatter.Formatter.Format(xml_string);

            xDoc.LoadXml(xml_string);
            var newDict = GetXmlDict(xDoc);

            var x = Enumerable.SequenceEqual(dictionary, newDict);

            return xml_string;
        }

        public static List<string> floatMatrixRowsNodes = new List<string>() { "row0", "row1", "row2", "row3" };
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

            if (element.ChildNodes.Cast<XmlNode>().Select(i => i.Name).OrderBy(i => i).SequenceEqual(floatMatrixRowsNodes))
            {
                //do not process children for transformation matrix
                return result;
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

            result = result.Distinct().OrderBy(i => i, StringComparer.Ordinal).ToList();

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
        public static void EncodePackedFile(string xml, out byte[] bytes)
        {
            var PS = new Packed_Section();

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);

            var f = new MemoryStream();
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

            bytes = f.ToArray();

            f.Close();
        }
    }
}
