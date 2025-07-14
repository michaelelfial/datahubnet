using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    internal class DataNodeSet<TModel> : IHubNode {
        private List<DataNode<TModel>> _Nodes = new List<DataNode<TModel>>();
        public DataNodeSet(string[]? path) {
            Path = path;
        }
        public string[]? Path { get; private set; }

        public Type DataType => typeof(TModel);

        List<DataNode<TModel>> Lock(LockMode mode = LockMode.None) {


    }
}
