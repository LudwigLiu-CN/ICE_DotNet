using System;

namespace GameService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GameServiceUtil gameServiceUtil = new GameServiceUtil();
            Response re = gameServiceUtil.GetGameTag(1);
            int b = 0;
        }
    }
}
