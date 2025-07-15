using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class EventEmitter<H>: IEventEmitter<H> where H: EventBase {

        private List<Action<H>> _Handlers = new();

        public void Subscribe(Action<H> handler) {
            _Handlers.Add(handler);
        }
        public void Unsubscribe(Action<H> handler) { 
            var index = _Handlers.IndexOf(handler);
            if (index >= 0) {
                _Handlers.RemoveAt(index);
            }
        }
        public void UnsubscribeAll() { 
            _Handlers.Clear();
        }

        public void Fire(H h) {
            foreach (var handler in _Handlers) {
                handler(h);
            }
        }
        public H Event() {
            var e = new H();
            e.SetNode(this_node);
                return e;
        }
        public void Fire() {
            var e = new H();
            e.SetNode(this_node)

        }

        public void Subscribe(Action handler) {
            if (handler is Action<H> ah) {
                Subscribe(ah);
                return;
            }
            throw new Exception("Not matching event type");
        }

        public void Unsubscribe(Action handler) {
            if (handler is Action<H> ah) {
                var i = _Handlers.IndexOf(ah);
                if (i >= 0) _Handlers.RemoveAt(i);
            }
            
        }

        public void Fire(object h) {
            if (h is Action<H> ah) {
                Fire(ah);
            }
        }
    }
}
