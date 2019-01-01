using FicheUtilities.Storage.API;

namespace FicheUtilities.DiskStatus.Tests
{
    public class FakeStatusData : IStatusData
    {
        public double AvailableGigabytes => 44.2D;

        public double TotalGigabytes => 111.79D;

        public double UsedGigabytes => 67.59D;
    }
}
