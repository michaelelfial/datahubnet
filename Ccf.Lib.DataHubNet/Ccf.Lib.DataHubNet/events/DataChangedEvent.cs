using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class DataChangedEvent<TModel>: EventBase<TModel> {

        public DataChangedEvent() { }
        public DataChangedEvent(DataNode<TModel> node):base(node) { }

    }

    public class SetChangedEvent<TModel> : SetEventBase<TModel> {
        public SetChangedEvent():base() { }
        public SetChangedEvent(DataNodeSet<TModel> node) : base(node) { }
    }
}
