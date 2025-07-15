using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class SetEventBase<TModel>: IEventBase<DataNodeSet<TModel>> {
        public DataNodeSet<TModel>? Node { get; private set; }

        public SetEventBase() { }
        public SetEventBase(DataNodeSet<TModel> nodeset) {
            Node = nodeset;
        }

        void IEventBase<DataNodeSet<TModel>>.SetNode(DataNodeSet<TModel> node) {
            Node = node;
        }

    }
}
