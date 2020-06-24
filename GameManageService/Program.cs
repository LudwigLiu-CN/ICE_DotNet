using System;

namespace GameManageService
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManageServiceUtil gameManageServiceUtil = new GameManageServiceUtil();
            var result = gameManageServiceUtil.getAllTags();
            Console.WriteLine(result.status);
            Console.WriteLine("Hello World!");
        }
    }
}
