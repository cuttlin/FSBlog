using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FSBlog.Models;

namespace FSBlog.Controllers
{
    public class MessageController : Controller
    {
        /// <summary>
        /// 注入目录
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;

        public MessageController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index(string uname, string uemail, string txt)
        {
            XmlDocument doc = new XmlDocument();
            // 存放消息
            if (!string.IsNullOrEmpty(uname) && !string.IsNullOrEmpty(uemail) && !string.IsNullOrEmpty(txt))
            {
                doc.Load(_hostingEnvironment.WebRootPath + @"\data\board.xml");
                XmlElement root = doc.DocumentElement;
                int id = 0;
                if (root.ChildNodes.Count > 0)//如果没有消息就从0开始
                {
                    id = Convert.ToInt32(root.LastChild.Attributes["id"].Value);
                }
                ++id;
                XmlElement message = doc.CreateElement("message");
                message.SetAttribute("id", id.ToString());
                message.SetAttribute("ip", HttpContext.Session.GetString("uip"));
                XmlElement name = doc.CreateElement("name");
                XmlElement email = doc.CreateElement("email");
                XmlElement time = doc.CreateElement("time");
                XmlElement content = doc.CreateElement("content");
                name.InnerText = uname;
                email.InnerText = uemail;
                time.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                content.InnerText = txt;
                message.AppendChild(name);
                message.AppendChild(email);
                message.AppendChild(time);
                message.AppendChild(content);
                root.AppendChild(message);
                doc.Save(_hostingEnvironment.WebRootPath + @"\data\board.xml");
            }
            // 读取消息
            List<Message> list = new List<Message>();
            doc.Load(_hostingEnvironment.WebRootPath + @"\data\board.xml");
            XmlElement r = doc.DocumentElement;
            XmlNode xn;
            Message m;
            for (int i = 1; i <= r.ChildNodes.Count; i++)
            {
                m = new Message();
                xn = r.SelectSingleNode("/board/message[@id=" + i + "]");
                m.Id = i;
                m.Ip = xn.Attributes["ip"].InnerText;
                m.Name = xn.ChildNodes[0].InnerText;
                m.Email = xn.ChildNodes[1].InnerText;
                m.Time = xn.ChildNodes[2].InnerText;
                m.Content = xn.ChildNodes[3].InnerText;
                list.Add(m);
            }
            return View(list);
        }

    }
}