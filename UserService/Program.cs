using DataAccessAPI.Models;
using HandleAddress;
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
            Response response = userServiceUtil.getAddress(1000023);
            int b = 0;
        }
    }
}
