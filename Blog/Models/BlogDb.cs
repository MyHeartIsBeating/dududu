using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class BlogDb : DbContext
    {
        public BlogDb() : base("DefaultConnection") { }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}