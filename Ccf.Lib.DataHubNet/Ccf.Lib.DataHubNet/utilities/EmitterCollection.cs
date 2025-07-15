using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class EmitterCollection: IEnumerable<IEventEmitter> {
        private Dictionary<Type, IEventEmitter> _Emitters = new();
        
        public EmitterCollection() {
        }
        
        void Add<H>(IEventEmitter<H> emitter) where H: EventBase {
            _Emitters.Add(typeof(H), emitter);
        }


        public EventEmitter<H>? Get<H>() where H: EventBase { 
                if (_Emitters.ContainsKey(typeof(H))) {
                    return _Emitters[typeof(H)] as EventEmitter<H>;
                } else {
                    var emitter = new EventEmitter<H>();
                    _Emitters.Add(typeof(H), emitter);
                    return emitter;
                }
        }
        

        public IEnumerator<IEventEmitter> GetEnumerator() {
            return _Emitters.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
