using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class DataChangedEvent<TModel>: EventBase {
        public DataChangedEvent(DataNode<TModel> node):base(node) {
            
        }
        DataNode<TModel>? DataNode => Node as DataNode<TModel>;
        //TModel? Data =

    }
}
