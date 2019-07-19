using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSBlog.Models
{
    /// <summary>
    /// 淘宝ip地址库返回模型
    /// </summary>
    public class IpAddressInfo

    {
        public int code { get; set; }
        public DataList data { get; set; }
    }
}
