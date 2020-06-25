using DataAccessAPI.Models;
using ResponseClass;
using System;
using System.Collections;

namespace UserService
{
    class Program
    {
        static UserServiceUtil userServiceUtil = new UserServiceUtil();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArrayList al = new ArrayList();
            al.Add("add1");
            al.Add("add2");
            Response a = userServiceUtil.UpdateAddress(al, 1000023);
            int b = 0;
        }
    }
}
