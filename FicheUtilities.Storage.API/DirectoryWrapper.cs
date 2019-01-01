using System.IO;

namespace FicheUtilities.Storage.API
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
