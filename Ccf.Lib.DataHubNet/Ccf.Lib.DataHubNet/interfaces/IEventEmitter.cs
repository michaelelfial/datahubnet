using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public interface IEventEmitter<H>: IEventEmitter where H: EventBase {
        void Subscribe(Action<H> handler);
        void Unsubscribe(Action<H> handler);
        new void UnsubscribeAll();
        void Fire(H h);
    }

    public interface IEventEmitter {
        void Subscribe(Action handler);
        void Unsubscribe(Action handler);
        void UnsubscribeAll();
        void Fire(object h);
    }
}
