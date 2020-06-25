using DataAccessAPI.Models;
using PublisherPageService;
using PublisherPageService.Models;
using System;

namespace PublisherPageController
{
    class Program
    {
        static void Main(string[] args)
        {
            PublisherPageServiceUtil publisherPageService = new PublisherPageServiceUtil();

            //Response result = publisherPageService.publisherInfo(1);

            Publishers publisher = new Publishers();
            publisher.PublisherName = "Naughty Dog";
            publisher.Pwd = "121212";
            publisher.Description = "description";

            Response result = publisherPageService.updatePublisherInfo(publisher,2);
            
            
            Console.WriteLine(result.status);

            //Response response = publisherPageService/*.*/

            Console.WriteLine("Hello World!");

        }
    }
}
