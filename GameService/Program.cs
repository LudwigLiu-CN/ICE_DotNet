using ResponseClass;
using System;

namespace GameService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GameServiceUtil gameServiceUtil = new GameServiceUtil();
            Response re = gameServiceUtil.GetGamePublisher(1);
            int b = 0;
        }
    }
}
