using FicheUtilities.Storage.API;

namespace FicheUtilities.Storage
{
    public static class StatusCheckerFactory
    {
        public static StatusChecker Create()
        {
            var checker = new StatusChecker(new DiskAPI(), new DirectoryWrapper());

            return checker;
        }
    }
}
