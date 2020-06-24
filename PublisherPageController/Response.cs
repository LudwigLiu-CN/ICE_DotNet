using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PublisherPageService
{
    class Response<T>
    {
        public String status { get; set; }
        public String error { get; set; }
        public List<T> result { get; set; }

        public Response()
        {
            result = new List<T>();
        }
    }
}
