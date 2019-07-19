using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSBlog.Models
{
    /// <summary>
    /// ipip.net ip地址库返回模型
    /// </summary>
    public class IpAddressInfo2
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Unit { get; set; }
        public string Isp { get; set; }
    }
}
