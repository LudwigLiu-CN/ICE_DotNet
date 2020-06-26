using DataAccessAPI.Models;
using PublisherPageService;
using PublisherPageService.Models;
using ResponseClass;
using System;
using HandleAddress;

namespace PublisherPageController
{
    class Program
    {
        static void Main(string[] args)
        {
            PublisherPageServiceUtil publisherPageService = new PublisherPageServiceUtil();

            //Response result = publisherPageService.publisherInfo(1);

            //Publishers publisher = new Publishers();
            //publisher.PublisherName = "Naughty Dog";
            //publisher.Pwd = "123456";
            //publisher.Description = "description";

            //Response result = publisherPageService.updatePublisherInfo(publisher,2);


            //Console.WriteLine(result.status);

            //Response response = publisherPageService/*.*/
            int a= AddressHelper.add(1, 2);

            Console.WriteLine("Hello World!"+a);

        }
    }
}
