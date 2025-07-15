using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    internal interface IEventBase<DN> : IEventBase where DN : IHubNode {
        void SetNode(DN node);
    }

    public interface IEventBase {}
}
