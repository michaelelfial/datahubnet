using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class EventEmitter<TNode,TEvent>: IEventEmitter<TEvent,TNode> 
        where TEvent: IEventBase<TNode>, new() 
        where TNode: IDataNode {


        private TNode _Node;
        private List<Action<TEvent>> _Handlers = new();

        public EventEmitter(TNode node) {
            _Node = node;
        }

        public void Subscribe(Action<TEvent> handler) {
            _Handlers.Add(handler);
        }
        public void Unsubscribe(Action<TEvent> handler) { 
            var index = _Handlers.IndexOf(handler);
            if (index >= 0) {
                _Handlers.RemoveAt(index);
            }
        }
        public void UnsubscribeAll() { 
            _Handlers.Clear();
        }

        public void Fire(TEvent h) {
            foreach (var handler in _Handlers) {
                handler(h);
            }
        }
        public TEvent Event() {
            var e = new TEvent();
            e.SetNode(_Node);
                return e;
        }
        public void Fire() {
            var e = new TEvent();
            e.SetNode(_Node);
            Fire(e);
        }

        public void Subscribe(Action handler) {
            if (handler is Action<TEvent> ah) {
                Subscribe(ah);
                return;
            }
            throw new Exception("Not matching event type");
        }

        public void Unsubscribe(Action handler) {
            if (handler is Action<TEvent> ah) {
                var i = _Handlers.IndexOf(ah);
                if (i >= 0) _Handlers.RemoveAt(i);
            }
            
        }

        public void Fire(object h) {
            if (h is TEvent ah) {
                Fire(ah);
            }
        }
    }
}
