using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using FSBlog.Models;

namespace FSBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public BlogController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> BlogList(string id)
        {
            XmlDocument doc = new XmlDocument();
            // 读取博客的category
            doc.Load(_hostingEnvironment.WebRootPath + @"/data/datadic.xml");
            Dictionary<int, string> dic = new Dictionary<int, string>();
            Dictionary<string, int> rdic = new Dictionary<string, int>();
            XmlElement root = doc.DocumentElement;
            XmlNode xn = root.SelectSingleNode("/root/category");
            ViewData["categoryCount"] = xn.ChildNodes.Count;
            for (int i = 1; i <= xn.ChildNodes.Count; i++)
            {
                dic.Add(i, xn.ChildNodes[i - 1].InnerText);
                rdic.Add(xn.ChildNodes[i - 1].InnerText, i);
            }
            ViewData["dic"] = dic;
            ViewData["rdic"] = rdic;
            doc.Load(_hostingEnvironment.WebRootPath + @"/data/blogrecard.xml");
            root = doc.DocumentElement;
            XmlNodeList xnl = root.SelectNodes("/root/blog[@type=1]");
            Blog b;
            List<Blog> list = new List<Blog>();
            foreach (XmlNode item in xnl)
            {
                b = new Blog();
                b.Id = Convert.ToInt32(item.Attributes["id"].InnerText);
                b.Name = item.Attributes["name"].InnerText;
                b.Category = item.Attributes["category"].InnerText;
                b.Path = item.ChildNodes[0].InnerText;
                b.Time = item.ChildNodes[1].InnerText;
                list.Add(b);
            }
            return View(list);
        }

        public async Task<IActionResult> BlogDetail(string id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_hostingEnvironment.WebRootPath + @"/data/blogrecard.xml");
            XmlElement root = doc.DocumentElement;
            XmlNode xn = root.SelectSingleNode("/root/blog[@id=" + id + "]");
            string path = xn.ChildNodes[0].InnerText;
            StreamReader sr = new StreamReader(_hostingEnvironment.WebRootPath + path);
            string str = sr.ReadToEnd();

            var result = CommonMark.CommonMarkConverter.Convert(str);
            ViewData["textc"] = result;
            ViewData["id"] = id;
            sr.Close();
            return View();
        }

        public async Task<IActionResult> Support([FromHeader]string detail)
        {
            XmlDocument d = new XmlDocument();
            d.Load(_hostingEnvironment.WebRootPath + Blog.BLOGRECARDPATH);
            XmlElement r = d.DocumentElement;
            XmlNode xn = r.SelectSingleNode("/root/blog[@id=" + detail + "]");
            int i = Convert.ToInt32(xn["support"].InnerText);
            xn["support"].InnerText = (++i).ToString();
            d.Save(_hostingEnvironment.WebRootPath + Blog.BLOGRECARDPATH);
            return Ok();
        }
    }
}