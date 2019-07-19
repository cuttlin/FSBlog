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


        public IActionResult Index()
        {
            ViewData["Title"] = "首页";
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
                doc.Save(_hostingEnvironment.WebRootPath + @"\data\userip.xml");
            }
            return View();
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
