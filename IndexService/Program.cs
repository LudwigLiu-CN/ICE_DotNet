﻿using System;

namespace IndexService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IndexServiceUtil indexServiceUtil = new IndexServiceUtil();
            Response re = indexServiceUtil.GetGames(true);
            int b = 0;
        }
    }
}
