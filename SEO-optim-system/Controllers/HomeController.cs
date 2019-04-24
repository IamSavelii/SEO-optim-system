using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEO_optim_system.Models;

namespace SEO_optim_system.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Check_site()
        {



            return View();
        }
        public IActionResult Data()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
        public IActionResult Directory()
        {
            return View();
        }
    }
}
