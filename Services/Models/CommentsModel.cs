using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class CommentsModel
    {
        public List<Comment> comments { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }

   

    public class Comment
    {
        public int id { get; set; }
        public string body { get; set; }
        public int postId { get; set; }
        public int likes { get; set; }
        public User user { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string fullName { get; set; }
    }

}
