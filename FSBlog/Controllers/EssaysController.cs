using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FSBlog.Controllers
{
    public class EssaysController : Controller
    {
        public IActionResult Index(string qq)
        {
            if (!string.IsNullOrEmpty(qq))
            {
                if (qq=="1")
                {
                    Response.Redirect("/Essays/EssaysList");
                }
            }
            return View();
        }

        public IActionResult EssaysList()
        {

            return View();
        }
    }
}