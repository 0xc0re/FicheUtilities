namespace FicheUtilities.DiskStatus.Core
{
    public interface IStatusData
    {
        double AvailableGigabytes { get; }
        double TotalGigabytes { get; }
        double UsedGigabytes { get; }
    }
}