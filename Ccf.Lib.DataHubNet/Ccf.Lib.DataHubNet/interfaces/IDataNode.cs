using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public interface IDataNode: IHubNode {
        object Lock(LockMode mode = LockMode.None);
        void Unlock(LockMode mode = LockMode.None);
        
    }
    public interface IDataNode<TModel>: IDataNode {
        new TModel Lock(LockMode mode = LockMode.None);
        new void Unlock(LockMode mode = LockMode.None);
    }
}
