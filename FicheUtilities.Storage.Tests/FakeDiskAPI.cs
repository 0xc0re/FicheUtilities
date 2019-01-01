using FicheUtilities.Storage.API;

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
