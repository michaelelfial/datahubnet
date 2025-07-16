using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public interface IEventBase<DN> : IEventBase where DN : IDataNode {
        void SetNode(DN node);
    }

    public interface IEventBase {}
}
