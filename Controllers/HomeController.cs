using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			// Get visit count from session
			int visitCount = -1;
			byte[] bytes;

			if (HttpContext.Session.TryGetValue("VisitCount", out bytes)) {
				visitCount = Convert.ToInt32(bytes[0]) + 1;
			}
			else {
				visitCount = 1;
			}

			HttpContext.Session.Set("VisitCount", new byte[] { Convert.ToByte(visitCount) });
            return View(visitCount);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
