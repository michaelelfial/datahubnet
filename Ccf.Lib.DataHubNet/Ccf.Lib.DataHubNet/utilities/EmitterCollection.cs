using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class EmitterCollection<TDataNode>: IEnumerable<IEventEmitter> 
        where TDataNode: IDataNode {

        TDataNode _Node;
        private Dictionary<Type, IEventEmitter> _Emitters = new();
        
        public EmitterCollection(TDataNode node) {
            _Node = node;
        }
        
        void Add<TEmiter>(TEmiter emitter) where TEmiter: IEventEmitter {
            _Emitters.Add(typeof(TEmiter), emitter);
        }
        void Add<TEvent>() where TEvent : IEventBase<TDataNode>, new() {
            Type type = typeof(EventEmitter<TDataNode,TEvent>);
            _Emitters.Add(type, new EventEmitter<TDataNode,TEvent>(_Node));
        }


        public EventEmitter<TDataNode,TEvent>? Emitter<TEvent>() where TEvent: IEventBase<TDataNode>, new() {
            var type = typeof(EventEmitter<TDataNode, TEvent>);
            EventEmitter<TDataNode, TEvent>? emitter;
            if (_Emitters.ContainsKey(type)) {
                emitter = _Emitters[type] as EventEmitter<TDataNode, TEvent>;
            } else {
                emitter = new EventEmitter<TDataNode, TEvent>(_Node);
                _Emitters.Add(type, emitter);
            }
            return emitter;
        }
        
        public TEvent Event<TEvent>() where TEvent: IEventBase<TDataNode>, new() {
            EventEmitter<TDataNode, TEvent>? emitter = Emitter<TEvent>();
            if (emitter == null) return default(TEvent);
            return emitter.Event();
        }

        public void Fire<TEvent>(TEvent e) where TEvent: IEventBase<TDataNode>, new() {
            Emitter<TEvent>()?.Fire(e);
        }
        public void Fire<TEvent>() where TEvent : IEventBase<TDataNode>, new() {
            Emitter<TEvent>()?.Fire();
        }

        public IEnumerator<IEventEmitter> GetEnumerator() {
            return _Emitters.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
