namespace FicheUtilities.Storage.API
{
    public interface IDiskAPI
    {
        IStatusData GetDiskStats(string DiskPath);
    }
}
