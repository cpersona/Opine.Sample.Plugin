using System;
using System.Threading.Tasks;
using Opine.Snapshots;

namespace Opine.Sample.Plugins.Snapshots
{
    public class SampleSnapshotStore : ISnapshotStore
    {
        public async Task<Snapshot> Read(Type type, object id)
        {
            return null;
        }

        public async Task Store(Snapshot snapshot)
        {
            
        }
    }
}