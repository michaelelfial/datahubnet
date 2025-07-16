namespace Ccf.Lib.DataHubNet {
    public class DataHub {

        Dictionary<string, IDataNode> _Nodes = new Dictionary<string, IDataNode>();

        #region Node definition
        public DataNode<TModel> DefineNode<TModel>(string path) {
            var node = new DataNode<TModel>(path);
            _Nodes.Add(path, node);
            return node;
        }
        public DataNodeSet<TModel> DefineNodeSet<TModel>(string path) {
            var node = new DataNodeSet<TModel>(path);
            _Nodes.Add(path, node);
            return node;
        }

        #endregion
        public NodeGetter<TModel> Nodes<TModel>() => new NodeGetter<TModel>(this);
        
        public NodeSetGetter<TModel> NodeSets<TModel>() => new NodeSetGetter<TModel>(this);

        #region Find etc
        public IDataNode? FindNode(string inpath) {
            if (_Nodes.ContainsKey(inpath)) return _Nodes[inpath];
            return null;
        }
        public DataNode<TModel>? FindNode<TModel>(string inpath) {
            if (_Nodes.ContainsKey(inpath) && _Nodes[inpath] is DataNode<TModel> node) {
                return node;
            }
            return null;
        }

        public DataNodeSet<TModel>? FindNodeSet<TModel>(string inpath) {
            if (_Nodes.ContainsKey(inpath) && _Nodes[inpath] is DataNodeSet<TModel> node) {
                return node;
            }
            return null;
        }
        #endregion

        #region Goodies
        public struct NodeGetter<TModel> {
            private DataHub hub;
            public NodeGetter(DataHub _hub) { this.hub = _hub; }
            public DataNode<TModel>? this[string inpath] => hub.FindNode<TModel>(inpath);
        }
        public struct NodeSetGetter<TModel> {
            private DataHub hub;
            public NodeSetGetter(DataHub _hub) { this.hub = _hub; }
            public DataNodeSet<TModel>? this[string inpath] => hub.FindNodeSet<TModel>(inpath);

        }
        #endregion
    }
}
