using DataAccessAPI.Models;
using HandleAddress;
using ResponseClass;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace UserService
{
    class Program
    {
        [DllImport(@"tsetDll.dll")]
        public static extern int test_fun();

        static UserServiceUtil userServiceUtil = new UserServiceUtil();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int b = test_fun();
            int c = 0;

            //string a = "233";
            //
            //sbyte[] sbArray = (sbyte[])((Array)System.Text.Encoding.Default.GetBytes(a));
            //unsafe
            //{
            //    fixed (sbyte* psb = sbArray)
            //    {
            //        AddressHelper addressHelper = new AddressHelper(psb);
            //        IntPtr b = (IntPtr)addressHelper.fuck();
            //        string dhcsdhiu = b.ToString()
            //        int huid = 0;
            //    }
            //}
        }
    }
}
