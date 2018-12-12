using System;
using FicheUtilities.Storage.API;

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
