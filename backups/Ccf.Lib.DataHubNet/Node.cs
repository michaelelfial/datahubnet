using System.Collections;

namespace Ccf.Lib.DataHubNet
{
    public class Node: IEnumerable<INodeConverter>
    {
        private Lock _locker = new Lock();
        private object? _Data;
        /// <summary>
        /// Path relative to the parent node
        /// </summary>
        public string[]? Path { get; protected set; }
        
        public object? Lock() {
            if (_locker.TryEnter()) {
                return _Data;
            }
            return null;
        }
        public void Unlock(object changedData, object options) {

        }


        protected Dictionary<Type, INodeConverter> _Converters { get; private set; } = new();
        void Add(INodeConverter converter) {
            _Converters.Add(converter.Type, converter);
        }

        public IEnumerator<INodeConverter> GetEnumerator() {
            return _Converters.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        //static void Converter<T>(Node node)  {
    }
}
