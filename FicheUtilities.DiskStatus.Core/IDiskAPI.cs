using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicheUtilities.DiskStatus.Core
{
    public interface IDiskAPI
    {
        IStatusData GetDiskStats(string DiskPath);
    }
}
