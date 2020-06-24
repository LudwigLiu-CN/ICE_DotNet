using DataAccessAPI.Models;
using System;

namespace UserService
{
    class Program
    {
        static UserServiceUtil userServiceUtil = new UserServiceUtil();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Users user = new Users();
            user.UserName = "DYT";
            user.Pwd = "123456";
            int a = userServiceUtil.Login(user);
        }
    }
}
