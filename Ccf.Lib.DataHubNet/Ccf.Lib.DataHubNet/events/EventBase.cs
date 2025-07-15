using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class EventBase<TModel>: IEventBase<DataNode<TModel>> {
        public DataNode<TModel>? Node { get; private set; }

        public EventBase() {
        }
        public EventBase(DataNode<TModel> node) {
            Node = node;
        }

        void IEventBase<DataNode<TModel>>.SetNode(DataNode<TModel> node) {
            Node = node;
        }

        
    }
}
