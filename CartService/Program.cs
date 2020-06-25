using System;

namespace CartService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CartServiceUtil cartServiceUtil = new CartServiceUtil();
            Response re = cartServiceUtil.RemoveFromCart(1000002, 1);
            int b = 0;
        }
    }
}
