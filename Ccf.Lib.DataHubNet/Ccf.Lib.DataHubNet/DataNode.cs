
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Ccf.Lib.DataHubNet
{
    public class DataNode<TModel>: IDataNode<TModel>
    {

        protected DataNode() {
            Events = new(this);
        }
        internal DataNode(string path = null):this() { 
            Path = path;
        }
        //private Lock _locker = new Lock();
        private ModeTracker _Tracker = new ModeTracker();

        public EmitterCollection<DataNode<TModel>> Events { get; private set; }
        private TModel? _Data;
        /// <summary>
        /// Path relative to the parent node
        /// </summary>
        public string? Path { get; protected set; }

        public Type DataType => typeof(TModel);

        //internal TModel Data => _Data;
        public TModel? Lock(LockMode mode = LockMode.None) {
            _Tracker.PutLock(mode);
            return _Data;
            
        }
        public TModel New(TModel model, LockMode mode = LockMode.Create) { 
            throw new NotImplementedException(); 
        }

        public void Unlock(LockMode mode = LockMode.None) {
            if (mode.HasFlag(LockMode.Change)) {
                Events.Get<DataChangedEvent<TModel>>()?.Fire(this);
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
