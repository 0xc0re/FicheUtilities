namespace FicheUtilities.Storage.API
{
    public interface IDirectoryWrapper
    {
        bool Exists(string path);
    }
}
