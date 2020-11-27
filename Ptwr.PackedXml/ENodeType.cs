using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptwr.PackedXml
{
    public enum ENodeType : int
    {
        Element = 0x0,
        String = 0x1,
        Integer = 0x2,
        Float = 0x3,
        Boolean = 0x4,
        Base64 = 0x5,
    }
}
