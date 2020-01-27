using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Xml;
using FSBlog.Models;
using System.IO;

namespace FSBlog.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// 注入目录
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;

        public AdminController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromHeader]string uname, [FromHeader]string upwd)
        {
            if (string.IsNullOrEmpty(uname) && string.IsNullOrEmpty(upwd))
            {
                return Json(new { error = "error" });
            }
            if (uname == "fsblog" && upwd == "fsblog")
            {
                HttpContext.Session.SetString("login", "success");
                return Json(new { error = "success" });
            }
            else
            {
                return Json(new { error = "error" });
            }
        }

        public async Task<IActionResult> Manage()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("login")))
            {
                return Redirect("/Admin/Index");
            }
            else
            {
                ViewData["blist"] = Blog.GetAllBlogs(_hostingEnvironment.WebRootPath + Blog.BLOGRECARDPATH);
                return View();
            }
        }

        public async Task<IActionResult> UpLoadBlog()
        {
            Blog blog = new Blog();
            blog.Name = Request.Form["name"];
            blog.Category = Request.Form["category"];
            blog.Type = Convert.ToInt32(Request.Form["type"]);
            blog.Time = Request.Form["time"];
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files[0];
                blog.Path = @"\data\blogs\" + file.FileName;
            }
            else
            {
                blog.Path = @"\data\blogs\" + blog.Name;
            }
            blog.Id = Blog.GetMaxBlogId(_hostingEnvironment.WebRootPath + Blog.BLOGRECARDPATH) + 1;
            blog.SaveBlogRecardAsXml(_hostingEnvironment.WebRootPath + Blog.BLOGRECARDPATH);
            if (Request.Form["way"] == "1")//上传markdown文件
            {
                string filePhysicalPath = _hostingEnvironment.WebRootPath + @"\data\blogs\";
                //文件名+文件后缀名
                IFormFile file = Request.Form.Files[0];
                using (var stream = new FileStream(filePhysicalPath + file.FileName, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            else   //上传markdown字符
            {
                string markdowwn = Request.Form["markdown"];
            }
            return Ok();
        }
    }
}