namespace Ccf.Lib.DataHubNet
{
    public class DataHub
    {
        List<IDataNode> dataNodes = new();

        #region Node definition
        public DataNode<TModel> defineNode<TModel>(string[] path) {

        }
        //public

        #endregion

        #region Find etc
        public IDataNode? FindNode(string[] inpath) {
            return dataNodes.FirstOrDefault(n => n.ComparePath(inpath));
        }
        #endregion

    }
}
