﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PublisherManageOrderService

{
    class Response
    {
        public String status { get; set; }
        public String error { get; set; }
        public ArrayList result { get; set; }

        public Response()
        {
            result = new ArrayList();
        }
    }
}