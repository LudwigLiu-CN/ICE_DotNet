using System;
using System.Collections.Generic;
using System.Text;

namespace CommentService
{
    public class ReviewWithUser
    {
        public int userId { get; set; }
        public String username { get; set; }
        public String avatarPath { get; set; }
        public String content { get; set; }
        public DateTime reviewDate { get; set; }
    }
}
