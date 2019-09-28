using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace FSBlog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult BlogList()
        {
            return View();
        }
    }
}