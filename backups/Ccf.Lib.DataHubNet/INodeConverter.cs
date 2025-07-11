using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public interface INodeConverter {

        Type Type { get { return typeof(Object); } }
        /// <summary>
        /// Converts internal data to model
        /// </summary>
        /// <param name="data">ref to internal data</param>
        /// <returns>object model</returns>
        object Get(object data);
        /// <summary>
        /// Converts model to internal storage
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        object Set(object model);
    }

    public interface INodeConverter<Model> : INodeConverter {
        Type INodeConverter.Type { get {
                return typeof(Model);
            } 
        }
        Model Get<Model>(object data);
        object Set<Model>(Model model);
    }
}
