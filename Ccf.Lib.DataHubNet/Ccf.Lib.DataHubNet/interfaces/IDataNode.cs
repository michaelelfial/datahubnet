using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public interface IDataNode {
        object Lock(LockMode mode = LockMode.None);
        void Unlock(LockMode mode = LockMode.None);
        string[] Path { get; }

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
    public interface IDataNode<TModel>: IDataNode {
        new TModel Lock(LockMode mode = LockMode.None);
        new void Unlock(LockMode mode = LockMode.None);
        Type DataType { get {
                return typeof(TModel);
            } 
        }
    }
}
