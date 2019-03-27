using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WotTools
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\G\wot unpacked\packages\scripts\item_defs\customization\paints\list.xml";
            string unpackedPath = @"D:\G\wot unpacked\packages\scripts\item_defs\customization\paints\unpacked_list.xml";
            string repackedPath = @"D:\G\wot unpacked\packages\scripts\item_defs\customization\paints\repacked_list.xml";

            var f = new FileStream(path, FileMode.Open, FileAccess.Read);
            var reader = new BinaryReader(f);
            var head = reader.ReadInt32();

            if (head == Packed_Section.Packed_Header)
            {
                string xml = Ptwr.PackedXml.Reader.DecodePackedFile(reader, Path.GetFileName(path));
                f.Close();

                File.WriteAllText(unpackedPath, xml);

                Ptwr.PackedXml.Reader.EncodePackedFile(repackedPath, xml);

                bool equal = FileEquals(path, repackedPath);
            }

            Console.ReadLine();
        }

        static bool FileEquals(string fileName1, string fileName2)
        {
            var a = File.ReadAllBytes(fileName1);
            var b = File.ReadAllBytes(fileName2);

            var min = Math.Min(a.Length, b.Length);

            for (int i = 0; i < min; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
            // Check the file size and CRC equality here.. if they are equal...    
            using (var file1 = new FileStream(fileName1, FileMode.Open))
            using (var file2 = new FileStream(fileName2, FileMode.Open))
                return FileStreamEquals(file1, file2);
        }

        static bool FileStreamEquals(Stream stream1, Stream stream2)
        {
            const int bufferSize = 2048;
            byte[] buffer1 = new byte[bufferSize]; //buffer size
            byte[] buffer2 = new byte[bufferSize];
            while (true)
            {
                int count1 = stream1.Read(buffer1, 0, bufferSize);
                int count2 = stream2.Read(buffer2, 0, bufferSize);

                if (count1 != count2)
                    return false;

                if (count1 == 0)
                    return true;

                // You might replace the following with an efficient "memcmp"
                if (!buffer1.Take(count1).SequenceEqual(buffer2.Take(count2)))
                    return false;
            }
        }


    }
}
