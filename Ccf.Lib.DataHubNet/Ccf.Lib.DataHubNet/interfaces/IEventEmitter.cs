using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public interface IEventEmitter<TEvent>: IEventEmitter where TEvent: IEventBase {
        void Subscribe(Action<TEvent> handler);
        void Unsubscribe(Action<TEvent> handler);
        new void UnsubscribeAll();
        void Fire(TEvent h);
    }

    public interface IEventEmitter {
        void Subscribe(Action handler);
        void Unsubscribe(Action handler);
        void UnsubscribeAll();
        void Fire(object h);
    }
}
