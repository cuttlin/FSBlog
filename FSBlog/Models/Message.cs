using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSBlog.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Time { get; set; }
        public string Content { get; set; }
    }
}
