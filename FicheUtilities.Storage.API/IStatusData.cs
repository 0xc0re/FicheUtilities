namespace FicheUtilities.Storage.API
{
    public interface IStatusData
    {
        double AvailableGigabytes { get; }
        double TotalGigabytes { get; }
        double UsedGigabytes { get; }
    }
}