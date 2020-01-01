using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Path { get; set; }
        public string Time { get; set; }
        public string Category { get; set; }
    }
}
