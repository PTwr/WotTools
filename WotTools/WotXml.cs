using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotTools
{
    public static class WotXml
    {
        public static bool TryDecodeXml(string path, Stream stream, out string decodedXml, bool verbose = true, string rootName = null)
        {
            decodedXml = "";
            rootName = rootName ?? Path.GetFileName(path);

            var binaryReader = new BinaryReader(stream);
            var head = binaryReader.ReadInt32();

            if (head != Packed_Section.Packed_Header)
            {
                return verbose ? throw new InvalidDataException("File is not packed xml") : false;
            }

            string xml = Ptwr.PackedXml.Reader.DecodePackedFile(binaryReader, rootName);

            decodedXml = xml;

            return !string.IsNullOrWhiteSpace(xml);
        }

        public static bool TryDecodeXml(string filepath, out string decodedXml, bool verbose = true, string rootName = null)
        {
            decodedXml = "";

            if (!File.Exists(filepath))
            {
                return verbose ? throw new FileNotFoundException("Input file not found") : false;
            }

            using (var fileStream = File.OpenRead(filepath))
            {
                return TryDecodeXml(filepath, fileStream, out decodedXml, verbose, rootName);
            }
        }
        public static bool TryEncodeXml(string filepath, out string encodedXml, bool verbose = true, string rootName = null)
        {
            encodedXml = "";

            if (!File.Exists(filepath))
            {
                return verbose ? throw new FileNotFoundException("Input file not found") : false;
            }

            using (var fileStream = File.OpenRead(filepath))
            {
                return TryDecodeXml(filepath, fileStream, out encodedXml, verbose, rootName);
            }
        }
    }
}
