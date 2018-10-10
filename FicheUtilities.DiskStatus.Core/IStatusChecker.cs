using System.Collections.Generic;

namespace FicheUtilities.DiskStatus.Core
{
    public interface IStatusChecker
    {
        List<LogMessage> GetStatus(StatusOptions options);
    }
}