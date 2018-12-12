using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicheUtilities.Storage
{
    public interface IStatusCheckerFactory
    {
        IStatusChecker Create();
    }
}
