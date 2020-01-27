using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace FSBlog.Models
{
    public class Blog
    {
        public static string BLOGPATH = @"\data\blogs\";
        public static string BLOGRECARDPATH = @"\data\blogrecard.xml";
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Path { get; set; }
        public string Time { get; set; }
        public string Category { get; set; }
        public int Support { get; set; }
        public int Comment { get; set; }

        public static int GetMaxBlogId(string path)
        {
            XmlDocument d = new XmlDocument();
            d.Load(path);
            XmlElement r = d.DocumentElement;
            return Convert.ToInt32(r.SelectSingleNode("//blog/@id[not(.<//blog/@id)]").InnerText);
        }
        public static List<Blog> GetAllBlogs(string path)
        {
            List<Blog> blogs = new List<Blog>();
            XmlDocument d = new XmlDocument();
            d.Load(path);
            XmlElement r = d.DocumentElement;
            Blog b = new Blog();
            XmlNode lastc = r.LastChild;
            b.Id = Convert.ToInt32(lastc.Attributes["id"].Value);
            b.Name = lastc.Attributes["name"].InnerText;
            b.Type = Convert.ToInt32(lastc.Attributes["type"].Value);
            b.Category = lastc.Attributes["category"].InnerText;
            b.Time = lastc["time"].InnerText;
            b.Support = Convert.ToInt32(lastc["support"].InnerText);
            b.Comment = Convert.ToInt32(lastc["comment"].InnerText);
            blogs.Add(b);
            for (int i = b.Id - 1; i > 0; i--)
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
                blogs.Add(b);
            }
            return blogs;
        }

        public bool SaveBlogRecardAsXml(string path)
        {
            try
            {
                XmlDocument d = new XmlDocument();
                d.Load(path);
                XmlElement r = d.DocumentElement;
                XmlElement blog = d.CreateElement("blog");
                blog.SetAttribute("id", this.Id.ToString());
                blog.SetAttribute("name", this.Name);
                blog.SetAttribute("type", this.Type.ToString());
                blog.SetAttribute("category", this.Category);
                XmlElement bpath = d.CreateElement("path");
                bpath.InnerText = this.Path;
                XmlElement time = d.CreateElement("time");
                time.InnerText = this.Time;
                XmlElement sup = d.CreateElement("support");
                sup.InnerText = this.Support.ToString();
                XmlElement com = d.CreateElement("comment");
                com.InnerText = this.Comment.ToString();
                blog.AppendChild(bpath);
                blog.AppendChild(time);
                blog.AppendChild(sup);
                blog.AppendChild(com);
                r.AppendChild(blog);
                d.Save(path);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
