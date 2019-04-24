using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEO_optim_system.Models;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Network.Default;

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

        public JsonResult GetSpam() {
            return Json(DateTime.Now);
        }

        public async Task<JsonResult> GetParametrs(string url) {
            return Json(new
            {
                YandexSQI = await YandexSQI(url),

                HUI = "HUI"
            });

        }

        public async Task<string> YandexSQI(string url)
        {
            var adress = "https://seobudget.ru/freechecker/site/" + url;
            var requester = new HttpRequester(adress);
            requester.Headers["User-Agent"] = "Dinamokid";
            var configuration = Configuration.Default.WithDefaultLoader(requesters: new[] { requester });
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader().WithCss().WithCookies());
            var document = await context.OpenAsync(adress);
            var result = document.QuerySelector("span.success").TextContent;
            return await Delete(result);
        }

        public async Task<string> Delete(string text){
            return String.Join("", text.Split('.')).Trim();
        }
    }
}
