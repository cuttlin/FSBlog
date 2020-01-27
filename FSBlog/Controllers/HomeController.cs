using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FSBlog.Models;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Text;

namespace FSBlog.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 注入目录
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task<IActionResult> Index(string count)
        {
            ViewData["Title"] = "首页";
            
            #region 获取访问IP信息
            if (HttpContext.Session.GetString("isfirstreq") == null)
            {
                HttpContext.Session.SetString("isfirstreq", "isfirstreq");

                string ip = GetRealIP();

                // 淘宝的ip库，不稳定
                string url = "http://ip.taobao.com/service/getIpInfo.php?ip=" + ip;
                string address = string.Empty;
                try
                {
                    string strJson = WebRequestHelper.GetUrl(url);
                    IpAddressInfo inf = JsonHelper.StringToEnteity<IpAddressInfo>(strJson);
                    address += inf.data.country + "|" + inf.data.region + "|" + inf.data.city +"|"+inf.data.area +"|" + inf.data.isp;
                   
                }
                catch (Exception)
                {
                    try
                    {
                        // ipip.net的库，比较稳定，备用ip库
                        url = "http://freeapi.ipip.net/" + ip;
                        string strJson = WebRequestHelper.GetUrl(url);
                        strJson = strJson.Replace(",", "|");
                        strJson = strJson.Replace("[", "");
                        strJson = strJson.Replace("]", "");
                        strJson = strJson.Replace("\"", "");
                        address += strJson;
                    }
                    catch (Exception)
                    {
                        address = "未知";
                    }
                }
                
                XmlDocument doc = new XmlDocument();

                doc.Load(_hostingEnvironment.WebRootPath+@"\data\userip.xml");
                XmlElement root = doc.DocumentElement;
                
                XmlNode xn = root.SelectSingleNode(@"/users/user[@ip='" + ip + "']");
                if (xn == null)
                {
                    XmlElement user = doc.CreateElement("user");
                    user.SetAttribute("ip", ip);
                    XmlElement times = doc.CreateElement("times");
                    times.InnerText = "1";
                    user.AppendChild(times);
                    XmlElement accesstime = doc.CreateElement("accesstime");
                    XmlElement time = doc.CreateElement("time");
                    time.SetAttribute("address", address);
                    time.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    accesstime.AppendChild(time);
                    user.AppendChild(accesstime);
                    root.AppendChild(user);
                }
                else
                {
                    int times = Convert.ToInt32(xn["times"].InnerText);
                    ++times;
                    xn["times"].InnerText = times.ToString();
                    XmlElement time = doc.CreateElement("time");
                    time.SetAttribute("address", address);
                    time.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    xn["accesstime"].AppendChild(time);
                }
                HttpContext.Session.SetString("uip", ip);
                doc.Save(_hostingEnvironment.WebRootPath + @"\data\userip.xml");
            }
            #endregion

            // 加载第一项
            List<Blog> list = new List<Blog>();
            XmlDocument d = new XmlDocument();
            d.Load(_hostingEnvironment.WebRootPath + @"\data\blogrecard.xml");
            XmlElement r = d.DocumentElement;
            XmlNode lastc = d.LastChild;
            lastc = lastc.LastChild;
            Blog b = new Blog();
            b.Id = Convert.ToInt32(lastc.Attributes["id"].Value);
            b.Name = lastc.Attributes["name"].InnerText;
            b.Type = Convert.ToInt32(lastc.Attributes["type"].Value);
            b.Category = lastc.Attributes["category"].InnerText;
            b.Time = lastc["time"].InnerText;
            b.Support = Convert.ToInt32(lastc["support"].InnerText);
            b.Comment = Convert.ToInt32(lastc["comment"].InnerText);
            ViewData["blog"] = b;
            int maxb = b.Id;
            // 加载剩余项
            for (int i = b.Id-1; i > 0; i--)
            {
                b = new Blog();
                b.Id = i;
                b.Name = r.SelectSingleNode("/root/blog[@id=" + i + "]").Attributes["name"].InnerText;
                b.Type = Convert.ToInt32(r.SelectSingleNode("/root/blog[@id=" + i + "]").Attributes["type"].InnerText);
                b.Category = r.SelectSingleNode("/root/blog[@id=" + i + "]").Attributes["category"].InnerText;
                b.Path = r.SelectSingleNode("/root/blog[@id=" + i + "]").ChildNodes[0].InnerText;
                b.Time = r.SelectSingleNode("/root/blog[@id=" + i + "]").ChildNodes[1].InnerText;
                b.Support = Convert.ToInt32(r.SelectSingleNode("/root/blog[@id=" + i + "]")["support"].InnerText);
                b.Comment = Convert.ToInt32(r.SelectSingleNode("/root/blog[@id=" + i + "]")["comment"].InnerText);
                list.Add(b);
            }
            
            if (string.IsNullOrEmpty(count))
            {
                ViewData["count"] = 2;
            }
            else if (Convert.ToInt32(count)-maxb>=3)
            {
                ViewData["out"] = 1;
                ViewData["count"] = count;
            }
            else
            {
                ViewData["count"] = count;
            }
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /// <summary>
        /// 获取真ip
        /// </summary>
        /// <returns></returns>
        public string GetRealIP()
        {
            var ip = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Connection.RemoteIpAddress.ToString();
            }
            return ip;

            //HttpContextAccessor context = new HttpContextAccessor();
            //var ip = context.HttpContext?.Connection.RemoteIpAddress.ToString();
            //return ip;
        }

        
        
    }
}
