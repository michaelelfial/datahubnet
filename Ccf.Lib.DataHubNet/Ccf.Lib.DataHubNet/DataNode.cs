
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Ccf.Lib.DataHubNet
{
    public class DataNode<TModel>: IDataNode<TModel>
    {

        internal DataNode(string[]? path = null) { 
            Path = path;
        }
        //private Lock _locker = new Lock();
        private ModeTracker _Tracker = new ModeTracker();

        public EmitterCollection Events { get; private set; } = new EmitterCollection();
        private TModel _Data;
        /// <summary>
        /// Path relative to the parent node
        /// </summary>
        public string[]? Path { get; protected set; }

        public Type DataType => typeof(TModel);

        //internal TModel Data => _Data;
        public TModel Lock(LockMode mode = LockMode.None) {
            _Tracker.PutLock(mode);
            return _Data;
            
        }
        public TModel New(TModel model, LockMode mode = LockMode.Create) { 
            throw new NotImplementedException(); 
        }

        public void Unlock(LockMode mode = LockMode.None) {
            if (mode.HasFlag(LockMode.Change)) {
                Events.Get<DataChangedEvent>()?.Fire(this);
                //Events.Get<StoreDataEvent>()?.Fire(this);
            }
            throw new NotImplementedException();
        }

        object IDataNode.Lock(LockMode mode) {
            return Lock(mode);
        }
        //static void Converter<T>(Node node)  {
    }
}
