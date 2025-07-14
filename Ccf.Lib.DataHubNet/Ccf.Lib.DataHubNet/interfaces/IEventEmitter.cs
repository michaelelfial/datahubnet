using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public interface IEventEmitter<H>: IEventEmitter where H: Delegate {
        void Subscribe(H handler);
        void Unsubscribe(H handler);
        void UnsubscribeAll();


        H Fire { get; }
    }

    public interface IEventEmitter {
        void UnsubscribeAll();
    }
}
