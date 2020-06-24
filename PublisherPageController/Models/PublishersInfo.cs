using System;
using System.Collections.Generic;
using System.Text;

namespace PublisherPageService.Models
{
    class PublishersInfo
    {
        public int publisherId{ get; set; }
        public String publisherName { get; set; }
        public String logoPath { get; set; }
        public String pwd { get; set; }
        public String description { get; set; }
    }
}
