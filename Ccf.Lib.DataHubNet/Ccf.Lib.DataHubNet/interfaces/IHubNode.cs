using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    /// <summary>
    /// Base interface for a data node in the hub, 
    /// this mostly takes care for the address and model's data type
    /// </summary>
    public interface IHubNode {
        string[]? Path { get; }

        Type DataType { get; }

        bool ComparePath(string[] inpath) {
            if (inpath == null || inpath.Length == 0) return false;
            if (Path != null && Path.Length > 0) {
                for (int i = 0; i < inpath.Length; i++) {
                    if (i < Path.Length) {
                        if (string.Compare(inpath[i], Path[i]) == 0) continue;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
