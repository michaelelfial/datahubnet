using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class StoreDataEvent: EventBase {
        public StoreDataEvent(IDataNode node): base(node) {
            
        }
    }
}
