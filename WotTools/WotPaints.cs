using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WotTools.XmlModels;

namespace WotTools
{
    public static class WotPaints
    {
        public static bool TryLoadPaints(string filePath, out listxml xmlModel, bool verbose = true)
        {
            xmlModel = null;
            if (!File.Exists(filePath))
            {
                return verbose ? throw new FileNotFoundException("Paint definition file not found") : false;
            }

            try
            {
                IXmlSerializerHelper xmlSerializerHelper = new XmlSerializerHelper();
                var xml = File.ReadAllText(filePath);
                xmlModel = xmlSerializerHelper.DeserializeFromXml<listxml>(xml);
            }
            catch(Exception e)
            {
                return verbose ? throw e: false;
            }

            return true;
        }

        public static string SerializeToXml(listxml xmlModel)
        {
            IXmlSerializerHelper xmlSerializerHelper = new XmlSerializerHelper();
            return xmlSerializerHelper.SerializeToXml(xmlModel, encoding: Encoding.ASCII);
        }
    }
}
