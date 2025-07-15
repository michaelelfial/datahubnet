using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class DataNodeSet<TModel> : IDataNode<List<DataNode<TModel>>> {
        private List<DataNode<TModel>> _Nodes = new List<DataNode<TModel>>();
        private ModeTracker _Tracker = new();
        private int _Limit;

        public DataNodeSet(string[]? path, int limit = -1) {
            Path = path;
            _Limit = limit;
        }
        public string[]? Path { get; private set; }

        public Type DataType => typeof(TModel);

        public DataNode<TModel> this[int index] {
            get { 
                if (index >= 0 && index < _Nodes.Count) {
                    return _Nodes[index];
                } else {
                    throw new IndexOutOfRangeException();
                }
                
            }
        }
        public int Count => _Nodes.Count;
        public DataNode<TModel> Add(DataNode<TModel> node, LockMode mode = LockMode.None) {
            if (_Limit > 0 && _Nodes.Count > _Limit) throw new IndexOutOfRangeException();
            _Tracker.PutLock(mode);
            _Nodes.Add(node);
            return node;
        }

        public List<DataNode<TModel>> Lock(LockMode mode = LockMode.None) {
            _Tracker.PutLock(mode);
            return _Nodes;
        }
        public void Unlock(LockMode mode = LockMode.None) {
            _Tracker.LiftLock(mode);
        }

        List<DataNode<TModel>> IDataNode<List<DataNode<TModel>>>.Lock(LockMode mode) {
            return Lock(mode);
        }

        void IDataNode<List<DataNode<TModel>>>.Unlock(LockMode mode) {
            Unlock(mode);
        }

        object IDataNode.Lock(LockMode mode) {
            return Lock(mode);
        }

        void IDataNode.Unlock(LockMode mode) {
            Unlock(mode);
        }
    }
}
