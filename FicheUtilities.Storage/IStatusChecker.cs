using System.Collections.Generic;

namespace FicheUtilities.Storage
{
    public interface IStatusChecker
    {
        List<LogMessage> GetStatus(StatusOptions options);
    }
}