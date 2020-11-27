using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ptwr.PackedXml;

namespace WotTools.Tests
{
    [TestClass]
    [DeploymentItem(@"InputData\" + encodedFile)]
    [DeploymentItem(@"InputData\" + decodedFile)]
    public class PackedXmlTests
    {
        private const string encodedFile = @"A63_M46_Patton_encoded.xml";
        private const string decodedFile = @"A63_M46_Patton_decoded.xml";
        private const string originalFile = "A63_M46_Patton.xml";

        [TestMethod]
        public void DecodeTest()
        {
            bool success = WotXml.TryDecodeXml(encodedFile, out var actual, rootName: originalFile);
            var expected = File.ReadAllText(decodedFile);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void ReadHeader()
        {
            using (var reader = new PackedXml.PackedXmlReader(encodedFile, originalFile))
            {
                reader.ReadHeader();
            }
        }

        [TestMethod]
        public void ReadDictionary()
        {
            List<string> expected = null;
            using (var fileStream = File.OpenRead(encodedFile))
            using (var binaryReader = new BinaryReader(fileStream))
            {
                binaryReader.ReadInt32(); //header
                binaryReader.ReadSByte(); //skip byte

                var PS = new Packed_Section();

                expected = PS.readDictionary(binaryReader);
            }
            using (var reader = new PackedXml.PackedXmlReader(encodedFile, originalFile))
            {
                reader.ReadHeader();
                var actual = reader.ReadDictionary();

                Assert.IsNotNull(actual);
                Assert.AreEqual(expected.Count, actual.Count);
                CollectionAssert.AreEqual(expected, actual);
            }

        }

        [TestMethod]
        public void NewReaderTest()
        {
            bool success = WotXml.TryDecodeXml(encodedFile, out var expected, rootName: originalFile);
            using (var reader = new PackedXml.PackedXmlReader(encodedFile, originalFile))
            {
                var actual = reader.Decode();
                Assert.AreEqual(expected, actual);
            }
        }

    }
}
