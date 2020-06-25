using System;

namespace IndexService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IndexServiceUtil indexServiceUtil = new IndexServiceUtil();
            Response re = indexServiceUtil.GetGames(true);
            Response re1 = indexServiceUtil.SortGames(1);
            int b = 0;
        }
    }
}
