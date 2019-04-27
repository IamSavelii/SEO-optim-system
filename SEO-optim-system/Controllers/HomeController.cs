﻿using AngleSharp;
using AngleSharp.Network.Default;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SEO_optim_system.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

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

        public JsonResult GetSpam()
        {
            return Json(DateTime.Now);
        }

        public async Task<JsonResult> GetParametrs(string url)
        {
            var trstspm = await GetSpamAndTrast(url);
            if (trstspm[0] == "True")
            {
                return Json(new
                {
                    status = trstspm[0],
                    site = url,
                    pageTitle = await GetTitle(url),
                    pageDescription = await GetDescription(url),
                    SQI = await YandexSQI(url),
                    trast = trstspm[1],
                    spam = trstspm[2],
                    hostLimitsBalance = trstspm[3]
                });
            }
            else
            {
                return Json(new
                {
                    status = trstspm[0],
                    message = "Неправильный URL"
                });
            }
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

        public async Task<string> Delete(string text)
        {
            return String.Join("", text.Split('.')).Trim();
        }

        public async Task<string> GetTitle(string url)
        {
            var adress = "http://e.megaindex.ru/analysis/" + url;
            var requester = new HttpRequester(adress);
            requester.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            requester.Headers["Accept-Charset"] = "utf-8";
            requester.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            var configuration = Configuration.Default.WithDefaultLoader(requesters: new[] { requester });
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader().WithCss().WithCookies());
            var document = await context.OpenAsync(adress);
            var result = document.QuerySelector("#set_title").TextContent;
            return await Delete(result);
        }

        public async Task<string> GetDescription(string url)
        {
            var adress = "https://be1.ru/stat/" + url;
            var requester = new HttpRequester(adress);
            requester.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            requester.Headers["Accept-Charset"] = "utf-8";
            requester.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            var configuration = Configuration.Default.WithDefaultLoader(requesters: new[] { requester });
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var document = await context.OpenAsync(adress);
            var result = document.QuerySelector("#set_description").TextContent;

            return await Delete(result);
        }

        public async Task<List<string>> GetSpamAndTrast(string url)
        {
            List<string> trtspm = new List<string>();
            var adress = "https://checktrust.ru/app.php?r=host/app/summary/basic&applicationKey=338bc2140502115cf718af016929edc6&host="  + url + "&parameterList=spam,trust";
            var requester = new HttpRequester(adress);
            requester.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            requester.Headers["Accept-Charset"] = "utf-8";
            requester.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            var configuration = Configuration.Default.WithDefaultLoader(requesters: new[] { requester });
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var document = await context.OpenAsync(adress);
            var json = document.QuerySelector("html").TextContent;
            var result = JsonConvert.DeserializeObject<Rootobject>(json);
            if (result.success == true)
            {
                string res = Convert.ToString(result.success);
                trtspm.Add(res); // [0]
                trtspm.Add(result.summary.trust); // [1]
                trtspm.Add(result.summary.spam); // [2]
                string balance = Convert.ToString(result.hostLimitsBalance);
                trtspm.Add(balance); //[3]
            }
            else
            {
                string res = Convert.ToString(result.success);
                trtspm.Add(res);
            }
            return trtspm;
        }

    }
    public class Rootobject
    {
        public bool success { get; set; }
        public Summary summary { get; set; }
        public int hostLimitsBalance { get; set; }
    }

    public class Summary
    {
        public string spam { get; set; }
        public string trust { get; set; }
        public string quality { get; set; }
    }
}

   