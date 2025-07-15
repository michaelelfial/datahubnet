using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class EventBase: IEventBase {
        public IDataNode Node { get; private set; }
        public EventBase(IDataNode node) {
            Node = node;
        }

        void IEventBase.SetNode(IDataNode node) {
            Node = node;
        }
    }
}
