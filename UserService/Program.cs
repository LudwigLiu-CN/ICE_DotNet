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
            user.UserName = "wdnmd";
            user.Pwd = "123456";
            Response a = userServiceUtil.Register(user);
            int b = 0;
        }
    }
}
