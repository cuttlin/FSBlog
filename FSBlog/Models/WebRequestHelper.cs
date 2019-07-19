using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FSBlog.Models
{
    public static class WebRequestHelper

    {
        /// <summary>
        ///以Get方式根据提供的地址  获取数据
        /// </summary>
        /// <param name="url">以Get方式根据提供的地址</param>
        /// <returns></returns>
        public static string GetUrl(string url)
        {
            string resultstring = string.Empty;
            Encoding encoding = Encoding.UTF8;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//这里的url指要获取的数据网址
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    resultstring = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw new Exception("接口错误！");
            }
            return resultstring;
        }
    }
}
