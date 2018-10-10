using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FicheUtilities.DiskStatus.Core;

namespace FicheUtilities.DiskStatus.Tests
{
    public class FakeStatusData : IStatusData
    {
        public double AvailableGigabytes => 44.2D;

        public double TotalGigabytes => 111.79D;

        public double UsedGigabytes => 67.59D;
    }
}
