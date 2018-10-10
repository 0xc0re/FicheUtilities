using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicheUtilities.DiskStatus.Core
{
    public class StatusOptions
    {
        public string Path { get; private set; }
        public double WarningThreshold { get; private set; }
        public double CriticalThreshold { get; private set; }
        public bool IsVerbose { get; private set; }

        public StatusOptions(string path, double warningThreshold, double criticalThreshold, bool isVerbose = false)
        {
            Path = path;
            WarningThreshold = warningThreshold;
            CriticalThreshold = criticalThreshold;
            IsVerbose = isVerbose;
        }
    }
}
