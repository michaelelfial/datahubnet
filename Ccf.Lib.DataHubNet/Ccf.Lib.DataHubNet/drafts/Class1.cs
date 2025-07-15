using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet.drafts {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Filter {
        public int Id { get; set; } = 0;
    }
    public class Comp1 {
        private DataNode<User> node;
        public Comp1(DataNode<User> user) {
            node = user; 
        }
        void Edit() {
            User u = node.Lock(LockMode.Exclusive);

        }
        void Ok() {
            User u = new User(); // Collect from UI
            node.Unlock(LockMode.Exclusive);
            node.Events.Get<DataChangedEvent>()?.Fire(u);
        }
    }
    public class Comp2 {
        private DataNode<User> node;
        public Comp1(DataNode<User> user) {
            node = user;
        }
    }
    public class UserStorage {
        public DataNode<User> User{ get;set { 
                value.Events.Get<StoreDataEvent>()?.Subscribe( handleStoreUser )
            } }
        private void handleStoreUser(StoreDataEvent e) {
            var userdata = e.DataNode.Lock();
            // save usedata

        }
    }

    internal class Class1 {
        void main() {

            DataNode<User> node = new();
            var storage_user = new UserStorage();
            storage_user.User = node;
            


        }
    }
}
