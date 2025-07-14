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
        
        void Add<T>(IEventEmitter<T> emitter) where T: Delegate {
            _Emitters.Add(typeof(T), emitter);
        }


        public EventEmitter<T> Get<T>() where T: Delegate { 
                if (_Emitters.ContainsKey(typeof(T))) {
                    return _Emitters[typeof(T)] as EventEmitter<T>;
                }
                return null;
        }

        public IEnumerator<IEventEmitter> GetEnumerator() {
            return _Emitters.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
