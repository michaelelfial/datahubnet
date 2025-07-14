using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class EventEmitter<H>: IEventEmitter<H> where H: Delegate {

        public void Subscribe(H handler) {

        }
        public void Unsubscribe(H handler) { }
        public void UnsubscribeAll() { }


        public H Fire { get; private set; }
        

    }
}
