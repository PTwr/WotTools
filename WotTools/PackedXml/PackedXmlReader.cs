using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WotTools.PackedXml
{
    public abstract class _BasePackedXml : IDisposable
    {
        public static readonly Int32 Packed_Header = 0x62A14E45;
        public static readonly char[] intToBase64 = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };

        protected BinaryReader binaryReader;
        protected Stream stream;

        public _BasePackedXml(Stream stream)
        {
            this.stream = stream;
            binaryReader = new BinaryReader(stream);
        }

        public virtual string ReadStringTillZero()
        {
            char[] buffer = new char[256];

            byte bufferPos = 0;
            for (char c = binaryReader.ReadChar(); c != 0; c = binaryReader.ReadChar())
            {
                buffer[bufferPos++] = c;
            }

            var result = new string(buffer, 0, bufferPos);
            return result;
        }

        public virtual List<string> ReadDictionary()
        {
            List<string> dictionary = new List<string>(512);

            for (string text = ReadStringTillZero(); text.Length > 0; text = ReadStringTillZero())
            {
                dictionary.Add(text);
            }

            return dictionary;
        }


        public virtual void Dispose()
        {
            binaryReader.Close();
            binaryReader.Dispose();

            stream.Close();
            stream.Dispose();
        }
    }
    public class PackedXmlReader : _BasePackedXml, IDisposable
    {
        private readonly string filePath;
        private readonly string rootName;

        public PackedXmlReader(string filePath, string rootName = null)
            : base(File.OpenRead(filePath))
        {
            this.filePath = filePath;
            this.rootName = rootName ?? Path.GetFileName(filePath);
        }

        public string Decode()
        {
            XmlDocument xDoc = new XmlDocument();
            var xmlroot = xDoc.CreateNode(XmlNodeType.Element, rootName, "");

            ReadHeader();
            var dictionary = ReadDictionary();
            ReadElement(xmlroot, xDoc, dictionary);

            var xml_string = xmlroot.OuterXml;
            xml_string = NXMLFormatter.Formatter.Format(xml_string);

            return xml_string;
        }

        public void ReadHeader()
        {
            var head = binaryReader.ReadInt32();
            if (head != Packed_Section.Packed_Header)
            {
                throw new InvalidDataException("File is not packed xml");
            }
            //skip one byte
            binaryReader.ReadSByte();
        }

        public void ReadElement(XmlNode parent, XmlDocument document, List<string> dictionary)
        {
            var childCount = binaryReader.ReadInt16();
            var descriptor = new PackedXmlDataDescriptor(binaryReader.ReadInt32());

            var elements = new PackedXmlElementDescriptor[childCount];
            for(int i = 0;i<childCount;i++)
            {
                var nameIndex = binaryReader.ReadInt16();
                elements[i] = new PackedXmlElementDescriptor(nameIndex, dictionary[i], binaryReader.ReadInt32());
            }

            //TODO offset
            //TODO readelements
        }
    }

    public class PackedXmlDataDescriptor
    {
        public readonly int end;
        public readonly EPackedXmlDataType type;

        public PackedXmlDataDescriptor(int encoded)
        {
            end = encoded & 0xFFFFFFF; //bottom 28 bits
            type = (EPackedXmlDataType)(encoded >> 28); //top 4 bits
        }
    }
    public class PackedXmlElementDescriptor : PackedXmlDataDescriptor
    {
        public readonly short nameIndex;
        public string name;

        public PackedXmlElementDescriptor(short nameIndex, string name, int encoded)
            : base(encoded)
        {
            this.nameIndex = nameIndex;
            this.name = name;
        }
    }

    public enum EPackedXmlDataType
    {
        Element = 0,
        String = 1,
        Integer = 2,
        Float = 3,
        Boolean = 4,
        Base64 = 5,
    }
}
