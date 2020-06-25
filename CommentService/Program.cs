using System;

namespace CommentService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CommentServiceUtil commentServiceUtil = new CommentServiceUtil();
            Response re = commentServiceUtil.CommentsNumber(4);
            int b = 0;
        }
    }
}
