using System;
using System.Collections.Generic;
using System.Globalization;
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

        public virtual string ReadString(int length)
        {
            if (length == 0)
            {
                //System.Diagnostics.Debugger.Break();
            }
            var str = new string(binaryReader.ReadChars(length));
            return str;
        }

        public virtual string ReadNumber(int length)
        {
            long n = 0;
            switch (length)
            {
                case 1:
                    n = binaryReader.ReadSByte();
                    break;
                case 2:
                    n = binaryReader.ReadInt16();
                    break;
                case 4:
                    n = binaryReader.ReadInt32();
                    break;
                case 8:
                    n = binaryReader.ReadInt64();
                    break;
            }
            return n.ToString(CultureInfo.InvariantCulture);
        }

        public virtual float[] ReadFloats(int length)
        {
            float[] result = new float[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = binaryReader.ReadSingle();
            }

            return result;
        }

        public string ReadBase64AsText(int length)
        {
            var bytes = binaryReader.ReadBytes(length);
            StringBuilder result = new StringBuilder();

            //TODO implement
            //6 bits per character

            //int triplets = bytes.Length / 3;
            int n;
            for (n = 0; n < bytes.Length; n += 3)
            {
                result.Append(ToBase64Char(bytes[n] >> 2));
                result.Append(ToBase64Char(bytes[n] << 4 | bytes[n + 1] >> 4));
                result.Append(ToBase64Char(bytes[n + 1] << 2 | bytes[n + 2] >> 6));
                result.Append(ToBase64Char(bytes[n + 2]));
            }
            n-=3;
            switch (bytes.Length % 3)
            {
                case 1:
                    result.Append(ToBase64Char(bytes[n] >> 2));
                    result.Append(ToBase64Char(bytes[n] << 4));
                    result.Append("==");
                    break;
                case 2:
                    result.Append(ToBase64Char(bytes[n] >> 2));
                    result.Append(ToBase64Char(bytes[n] << 4 | bytes[n + 1] >> 4));
                    result.Append(ToBase64Char(bytes[n + 1] << 2));
                    result.Append('=');
                    break;
            }


            return result.ToString();
        }

        private char ToBase64Char(int b)
        {
            return intToBase64[b & 0x3F];
        }

        public string ReadBase64ByteStream(int length)
        {
            var bytes = binaryReader.ReadBytes(length);
            var sb = new StringBuilder("[ ");
            foreach (var b in bytes)
            {
                sb.Append(Convert.ToString(b, 16));
                sb.Append(" ");
            }
            sb.Append("]L:");
            sb.Append(length);

            return sb.ToString();
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

        public void ReadElement(XmlNode element, XmlDocument document, List<string> dictionary)
        {
            var childCount = binaryReader.ReadInt16();
            var descriptor = new PackedXmlDataDescriptor(binaryReader.ReadInt32());

            var elements = new PackedXmlElementDescriptor[childCount];
            for (int i = 0; i < childCount; i++)
            {
                var nameIndex = binaryReader.ReadInt16();
                elements[i] = new PackedXmlElementDescriptor(nameIndex, dictionary[nameIndex], binaryReader.ReadInt32());
            }

            int offset = ReadElementData(element, document, dictionary, descriptor);

            foreach (var elementDescriptor in elements)
            {
                var elementName = dictionary[elementDescriptor.nameIndex];
                XmlNode child = document.CreateElement(elementName);
                offset = ReadElementData(child, document, dictionary, elementDescriptor, offset);
                element.AppendChild(child);
            }
        }

        public int ReadElementData(XmlNode element, XmlDocument document, List<string> dictionary, PackedXmlDataDescriptor descriptor, int offset = 0)
        {
            int lengthInBytes = descriptor.end - offset;

            switch (descriptor.type)
            {
                case EPackedXmlDataType.Element:
                    ReadElement(element, document, dictionary);
                    break;
                case EPackedXmlDataType.String:
                    element.InnerText = ReadString(lengthInBytes);
                    break;
                case EPackedXmlDataType.Integer:
                    element.InnerText = ReadNumber(lengthInBytes);
                    break;
                case EPackedXmlDataType.Float:
                    var floats = ReadFloats(lengthInBytes / 4)
                        .Select(f => f.ToString("0.000000", CultureInfo.InvariantCulture))
                        .ToList();

                    if (floats.Count == 12) //four rows of three floats
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            XmlNode row = document.CreateElement($"row{i}");
                            row.InnerText = string.Join(" ", floats.Skip(i * 3).Take(3));
                            element.AppendChild(row);
                        }
                    }
                    else
                    {
                        element.InnerText = string.Join(" ", floats);
                    }

                    break;
                case EPackedXmlDataType.Boolean:
                    //TODO is this correct?
                    if (lengthInBytes != 1)
                    {
                        element.InnerText = "false";
                    }
                    else
                    {
                        if (binaryReader.ReadSByte() != 1)
                        {
                            throw new System.ArgumentException("Boolean error");
                        }
                        element.InnerText = "true";
                    }
                    break;
                case EPackedXmlDataType.Base64:
                    element.InnerText = ReadBase64AsText(lengthInBytes);
                    break;
                default:
                    throw new ArgumentException($"Unknown type of element {element.Name}: {descriptor.type}");
            }
            if (element.Name == "weight" && element.InnerText == "10000")
            {
                lengthInBytes = lengthInBytes;
            }

            return descriptor.end;
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
