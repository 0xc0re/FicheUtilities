using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicheUtilities.DiskStatus.Core
{
    public class StatusCheckerFactory : IStatusCheckerFactory
    {
        public IStatusChecker Create()
        {
            var checker = new StatusChecker(new DiskAPI(), new DirectoryWrapper());

            return checker;
        }
    }
}
