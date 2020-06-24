using DataAccessAPI.Models;
using PublisherPageService;
using PublisherPageService.Models;
using System;
using System.Security.Policy;

namespace PublisherPageController
{
    class Program
    {
        static void Main(string[] args)
        {
            PublisherPageServiceUtil publisherPageService = new PublisherPageServiceUtil();
            Response<Publishers> result = publisherPageService.publisherInfo(1);
            Console.WriteLine(result.result[0].PublisherName);
            Console.WriteLine("Hello World!");

        }
    }
}
