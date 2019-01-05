using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ColourListEditor
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = false)]
    [System.Xml.Serialization.XmlRootAttribute("list.xml", Namespace = "", IsNullable = false)]
    public partial class listxml
    {

        private listxmlItemGroup[] itemGroupField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("itemGroup")]
        public listxmlItemGroup[] itemGroup
        {
            get
            {
                return this.itemGroupField;
            }
            set
            {
                this.itemGroupField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroup
    {

        private string nameField;

        private string userStringField;

        private string seasonField;

        private bool historicalField;

        private string priceGroupField;

        private listxmlItemGroupVehicleFilter vehicleFilterField;

        private listxmlItemGroupPaint[] paintField;

        private listxmlItemGroupUsages usagesField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string userString
        {
            get
            {
                return this.userStringField;
            }
            set
            {
                this.userStringField = value;
            }
        }

        /// <remarks/>
        public string season
        {
            get
            {
                return this.seasonField;
            }
            set
            {
                this.seasonField = value;
            }
        }

        /// <remarks/>
        public bool historical
        {
            get
            {
                return this.historicalField;
            }
            set
            {
                this.historicalField = value;
            }
        }

        /// <remarks/>
        public string priceGroup
        {
            get
            {
                return this.priceGroupField;
            }
            set
            {
                this.priceGroupField = value;
            }
        }

        /// <remarks/>
        public listxmlItemGroupVehicleFilter vehicleFilter
        {
            get
            {
                return this.vehicleFilterField;
            }
            set
            {
                this.vehicleFilterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("paint")]
        public listxmlItemGroupPaint[] paint
        {
            get
            {
                return this.paintField;
            }
            set
            {
                this.paintField = value;
            }
        }

        /// <remarks/>
        public listxmlItemGroupUsages usages
        {
            get
            {
                return this.usagesField;
            }
            set
            {
                this.usagesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroupVehicleFilter
    {

        private listxmlItemGroupVehicleFilterInclude[] includeField;

        private listxmlItemGroupVehicleFilterExclude excludeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("include")]
        public listxmlItemGroupVehicleFilterInclude[] include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }

        /// <remarks/>
        public listxmlItemGroupVehicleFilterExclude exclude
        {
            get
            {
                return this.excludeField;
            }
            set
            {
                this.excludeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroupVehicleFilterInclude
    {

        private string nationsField;

        private string tagsField;

        private string vehiclesField;

        private string levelsField;

        /// <remarks/>
        public string nations
        {
            get
            {
                return this.nationsField;
            }
            set
            {
                this.nationsField = value;
            }
        }

        /// <remarks/>
        public string tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
            }
        }

        /// <remarks/>
        public string vehicles
        {
            get
            {
                return this.vehiclesField;
            }
            set
            {
                this.vehiclesField = value;
            }
        }

        /// <remarks/>
        public string levels
        {
            get
            {
                return this.levelsField;
            }
            set
            {
                this.levelsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroupVehicleFilterExclude
    {

        private string vehiclesField;

        /// <remarks/>
        public string vehicles
        {
            get
            {
                return this.vehiclesField;
            }
            set
            {
                this.vehiclesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroupPaint
    {
        [XmlIgnore]
        public string PaintGroup { get; set; }

        [XmlIgnore]
        public bool Historical { get; set; }

        private ushort idField;

        private string textureField;

        private string colorField;

        private decimal glossField;

        private decimal metallicField;

        private string userStringField;

        private listxmlItemGroupPaintVehicleFilter vehicleFilterField;

        private string tagsField;

        private string seasonField;

        /// <remarks/>
        public ushort id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string texture
        {
            get
            {
                return this.textureField;
            }
            set
            {
                this.textureField = value;
            }
        }

        /// <remarks/>
        public string color
        {
            get
            {
                return this.colorField;
            }
            set
            {
                this.colorField = value;
            }
        }

        /// <remarks/>
        public decimal gloss
        {
            get
            {
                return this.glossField;
            }
            set
            {
                this.glossField = value;
            }
        }

        /// <remarks/>
        public decimal metallic
        {
            get
            {
                return this.metallicField;
            }
            set
            {
                this.metallicField = value;
            }
        }

        /// <remarks/>
        public string userString
        {
            get
            {
                return this.userStringField;
            }
            set
            {
                this.userStringField = value;
            }
        }

        /// <remarks/>
        public listxmlItemGroupPaintVehicleFilter vehicleFilter
        {
            get
            {
                return this.vehicleFilterField;
            }
            set
            {
                this.vehicleFilterField = value;
            }
        }

        /// <remarks/>
        public string tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
            }
        }

        /// <remarks/>
        public string season
        {
            get
            {
                return this.seasonField;
            }
            set
            {
                this.seasonField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroupPaintVehicleFilter
    {

        private listxmlItemGroupPaintVehicleFilterInclude includeField;

        private listxmlItemGroupPaintVehicleFilterExclude[] excludeField;

        /// <remarks/>
        public listxmlItemGroupPaintVehicleFilterInclude include
        {
            get
            {
                return this.includeField;
            }
            set
            {
                this.includeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("exclude")]
        public listxmlItemGroupPaintVehicleFilterExclude[] exclude
        {
            get
            {
                return this.excludeField;
            }
            set
            {
                this.excludeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroupPaintVehicleFilterInclude
    {

        private string levelsField;

        /// <remarks/>
        public string levels
        {
            get
            {
                return this.levelsField;
            }
            set
            {
                this.levelsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroupPaintVehicleFilterExclude
    {

        private string vehiclesField;

        private string nationsField;

        /// <remarks/>
        public string vehicles
        {
            get
            {
                return this.vehiclesField;
            }
            set
            {
                this.vehiclesField = value;
            }
        }

        /// <remarks/>
        public string nations
        {
            get
            {
                return this.nationsField;
            }
            set
            {
                this.nationsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroupUsages
    {

        private listxmlItemGroupUsagesItem itemField;

        /// <remarks/>
        public listxmlItemGroupUsagesItem item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class listxmlItemGroupUsagesItem
    {

        private string componentTypeField;

        private byte costField;

        /// <remarks/>
        public string componentType
        {
            get
            {
                return this.componentTypeField;
            }
            set
            {
                this.componentTypeField = value;
            }
        }

        /// <remarks/>
        public byte cost
        {
            get
            {
                return this.costField;
            }
            set
            {
                this.costField = value;
            }
        }
    }


}
