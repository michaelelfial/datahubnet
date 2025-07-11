using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    [Flags]
    public enum LockMode {
        None = 0,
        Read = 0x1,
        Change = 0x2,
        Delete = 0x4,
        Create = 0x8,
        Exclusive = 0x10,

        Full = 0x7,
        ReadWrite = 0x3
    }
}
