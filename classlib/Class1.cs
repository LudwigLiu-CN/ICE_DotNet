using System;
using System.Runtime.InteropServices;

namespace classlib
{
    [ComVisible(true)]
    [Guid("7E68B9FB-046A-43FB-97C7-B80669E22D98")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IServer
    {
        double ComputePi();
    }
    [Guid("C858C294-672E-462B-AC4E-062F861F0205")]
    [ComVisible(true)]
    public class Sever : IServer 
    {
        

        double IServer.ComputePi()
        {
            return 3.14;
        }
    }
}
