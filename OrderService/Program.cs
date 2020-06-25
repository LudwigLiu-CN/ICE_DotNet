using ResponseClass;
using System;

namespace OrderService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OrderServiceUtil orderServiceUtil = new OrderServiceUtil();
            Response re = orderServiceUtil.DeliverOrder(3);
            int b = 0;
        }
    }
}
