using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotTools.CLI
{
    public interface IOOptions
    {
        string Input { get; set; }
        string Output { get; set; }
    }
}
