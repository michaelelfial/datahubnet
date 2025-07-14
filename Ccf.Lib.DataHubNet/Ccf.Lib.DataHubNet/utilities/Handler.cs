using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class Handler<H> where H: Delegate {

        public Handler(H handler) {
            Handler = handler;
        }
        public H? Handler { get; private set; }

        void SubscribeFor(IDataNode node, string ecentKey) { 
        }
    }
}
