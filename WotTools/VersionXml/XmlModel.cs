using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotTools.VersionXml
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("version.xml", Namespace = "", IsNullable = false)]
    public partial class versionxml
    {

        private string appnameField;

        private string versionField;

        private byte showLicenseField;

        private byte ingameHelpVersionField;

        private versionxmlMeta metaField;

        /// <remarks/>
        public string appname
        {
            get
            {
                return this.appnameField;
            }
            set
            {
                this.appnameField = value;
            }
        }

        /// <remarks/>
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public byte showLicense
        {
            get
            {
                return this.showLicenseField;
            }
            set
            {
                this.showLicenseField = value;
            }
        }

        /// <remarks/>
        public byte ingameHelpVersion
        {
            get
            {
                return this.ingameHelpVersionField;
            }
            set
            {
                this.ingameHelpVersionField = value;
            }
        }

        /// <remarks/>
        public versionxmlMeta meta
        {
            get
            {
                return this.metaField;
            }
            set
            {
                this.metaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class versionxmlMeta
    {

        private uint clientField;

        private uint overridesField;

        private string localizationField;

        /// <remarks/>
        public uint client
        {
            get
            {
                return this.clientField;
            }
            set
            {
                this.clientField = value;
            }
        }

        /// <remarks/>
        public uint overrides
        {
            get
            {
                return this.overridesField;
            }
            set
            {
                this.overridesField = value;
            }
        }

        /// <remarks/>
        public string localization
        {
            get
            {
                return this.localizationField;
            }
            set
            {
                this.localizationField = value;
            }
        }
    }


}
