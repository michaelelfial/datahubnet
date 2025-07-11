using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccf.Lib.DataHubNet {
    public class ModeTracker {
        public ModeTracker(/* TODO policy*/) {
            var values = Enum.GetValues<LockMode>();
            foreach (var value in values) {
                modes[value] = 0;
            }
        }
        private Dictionary<LockMode,int> modes = new Dictionary<LockMode,int>();
        public bool PutLock(LockMode mode) {
            IterateModes(mode, m => {
                modes[m]++;
            });
            return true; // TODO policy
        }
        public void LiftLock(LockMode mode) {
            IterateModes(mode, m => {
                if (modes[m] > 0) modes[m]--;
            });
        }
        static void IterateModes(LockMode mode, Action<LockMode> proc) {
            var values = Enum.GetValues<LockMode>();
            foreach (var value in values) {
                if (mode.HasFlag(value)) {
                    proc(value);
                }
            }
        }
    }
}
