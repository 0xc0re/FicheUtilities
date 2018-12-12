using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FicheUtilities.Storage.API
{
    public class DiskAPI : IDiskAPI
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
            out ulong lpFreeBytesAvailable,
            out ulong lpTotalNumberOfBytes,
            out ulong lpTotalNumberOfFreeBytes);

        public IStatusData GetDiskStats(string DiskPath)
        {

            if (GetDiskFreeSpaceEx(DiskPath, out var _free, out var _total, out var _dummy2))
            {
                return new StatusData(_total, _free);
            }
            else
            {
                throw new Exception("There was an error talking to the disk. Refer to system error code: " + Marshal.GetLastWin32Error());
            }
        }
    }
}
