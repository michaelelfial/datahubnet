using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    internal interface IEventBase {
        IDataNode Node { get; }
        void SetNode(IDataNode node);
    }
}
