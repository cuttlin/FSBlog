using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using Microsoft.AspNetCore.Hosting;

namespace FSBlog.Controllers
{
    public class AboutController : Controller
    {
        /// <summary>
        /// 注入目录
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;

        public AboutController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index()
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(_hostingEnvironment.WebRootPath + @"\data\userip.xml");
            XmlElement root = doc.DocumentElement;
            XmlNodeList xnlt = root.SelectNodes("/users/user/times");
            XmlNodeList xnlu = root.SelectNodes("/users/user");
            int times = 0;
            int users = 0;
            foreach (XmlNode item in xnlt)
            {
                times += Convert.ToInt32(item.InnerText);
            }
            users = xnlu.Count;
            ViewData["count"] = times;
            ViewData["users"] = users;
            return View();
        }
    }
}