using System;

namespace RateService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RateServiceUtil rateServiceUtil = new RateServiceUtil();
            Response re = rateServiceUtil.GetMyRate(1000021, 3);
            int b = 0;
        }
    }
}
