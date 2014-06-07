using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int TopicId { get; set; }

    }
}
