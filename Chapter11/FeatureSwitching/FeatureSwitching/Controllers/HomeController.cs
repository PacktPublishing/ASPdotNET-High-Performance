using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeatureSwitching.Models;

namespace FeatureSwitching.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var rand = new Random();
            if (rand.Next(99) < 25)
            {
                return View();
            }
            return View("IndexOld");
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
