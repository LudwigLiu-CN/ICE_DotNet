using DataAccessAPI.Models;
using System;
using System.Collections;

namespace GameManageService
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManageServiceUtil gameManageServiceUtil = new GameManageServiceUtil();
            Response response = gameManageServiceUtil.getAllTags();
            Console.WriteLine(response);
            Console.WriteLine(response.status);
            Console.WriteLine(response.result);
            Console.WriteLine(response.result.Count);
            Tags tag = (Tags)response.result[0];
            Console.WriteLine(tag.TagName);



            Console.WriteLine("Hello World!");
        }
    }
}
