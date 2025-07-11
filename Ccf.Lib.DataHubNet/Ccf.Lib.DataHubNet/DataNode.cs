
using System.Collections;

namespace Ccf.Lib.DataHubNet
{
    public class DataNode<TModel>: IDataNode<TModel>
    {

        internal DataNode() { 
            // TODO
        }
        //private Lock _locker = new Lock();
        private ModeTracker _Tracker = new ModeTracker();
        private TModel? _Data;
        /// <summary>
        /// Path relative to the parent node
        /// </summary>
        public string[]? Path { get; protected set; }

        
        public TModel Lock(LockMode mode = LockMode.None) {
            throw new NotImplementedException();
        }
        public TModel New(TModel model, LockMode mode = LockMode.Create) { 
            throw new NotImplementedException(); 
        }

        public void Unlock(LockMode mode = LockMode.None) {
            throw new NotImplementedException();
        }

        object IDataNode.Lock(LockMode mode) {
            return Lock(mode);
        }
        //static void Converter<T>(Node node)  {
    }
}
