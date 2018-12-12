using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicheUtilities.Storage.API
{
    public interface IDirectoryWrapper
    {
        bool Exists(string path);
    }
}
