using FicheUtilities.Storage.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicheUtilities.DiskStatus.Tests
{
    public class FakeDiskAPI : IDiskAPI
    {
        public IStatusData GetDiskStats(string DiskPath)
        {
            return new FakeStatusData();
        }
    }
}
