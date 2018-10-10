using System;
using FicheUtilities.DiskStatus.Core;

namespace FicheUtilities.DiskStatus.Tests
{
    public class FakeDiskAPI_ThrowsExceptions : IDiskAPI
    {
        public IStatusData GetDiskStats(string DiskPath)
        {
            throw new Exception("Something went wrong!");
        }
    }
}
