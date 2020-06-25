using ResponseClass;
using System;

namespace PublisherManageOrderService
{
    class Program
    {
        static void Main(string[] args)
        {
            PublisherManageOrderUtil publisherManageOrderUtil = new PublisherManageOrderUtil();
            Console.WriteLine("---------------1-----------");
            Response response1 = publisherManageOrderUtil.initOrderList(10, 2);
            Console.WriteLine("status:" + response1.status);
            Console.WriteLine("result:" + response1.result);
            Console.WriteLine("count:" + response1.result.Count);
            OrderManager orderManager = (OrderManager)response1.result[0];
            Console.WriteLine("0ge:" +orderManager.user_name);

            Console.WriteLine("---------------2-----------");
            Response response2 = publisherManageOrderUtil.orderNumber( 2);
            Console.WriteLine("status:" + response2.status);
            Console.WriteLine("result:" + response2.result);
            Console.WriteLine("count:" + response2.result.Count);
            //OrderManager orderManager = (OrderManager)response1.result[0];
            Console.WriteLine("0ge:" + response2.result[0]);

            Console.WriteLine("---------------3-----------");
            Response response3 = publisherManageOrderUtil.alterOrder(19,1,10000,null,"110",2);
            Console.WriteLine("status:" + response3.status);
            Console.WriteLine("result:" + response3.result);
            Console.WriteLine("count:" + response3.result.Count);
            OrderManager orderManager3 = (OrderManager)response3.result[0];
            Console.WriteLine("0ge:" + orderManager3.user_name);

        }
    }
}
