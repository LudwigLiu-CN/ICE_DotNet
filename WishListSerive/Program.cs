using System;

namespace WishListSerive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WishListServiceUtil wishListServiceUtil = new WishListServiceUtil();
            Response re = wishListServiceUtil.GetMyWishList(1000009);
            int b = 0;
        }
    }
}
