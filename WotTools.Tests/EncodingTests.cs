using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ptwr.PackedXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WotTools.Tests
{
    [TestClass]
    [DeploymentItem(@"InputData\" + encodedFile)]
    [DeploymentItem(@"InputData\" + decodedFile)]
    public class EncodingTests
    {
        private const string encodedFile = @"A63_M46_Patton_encoded.xml";
        private const string decodedFile = @"A63_M46_Patton_decoded.xml";
        private const string originalFile = "A63_M46_Patton.xml";

        [TestMethod]
        public void TestDictionaryEncoding()
        {
            List<string> actualdictionary = null;
            using (var reader = new PackedXml.PackedXmlReader(encodedFile, originalFile))
            {
                reader.ReadHeader();
                actualdictionary = reader.ReadDictionary();

                var decoded = File.ReadAllText(decodedFile);

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(decoded);
                var newDict = Reader.GetXmlDict(xDoc);

                Assert.IsTrue(newDict.SequenceEqual(actualdictionary));
            }
        }

        [TestMethod]
        public void EncodeTest()
        {
            var decoded = File.ReadAllText(decodedFile);
            Reader.EncodePackedFile(decoded, out var actual);
            var expected = File.ReadAllBytes(encodedFile);
            //return;
            //Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
