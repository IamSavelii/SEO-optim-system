﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEO_optim_system.Models;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Network.Default;
using System.IO;
using System.Net.Http;
using HttpMethod = AngleSharp.Network.HttpMethod;

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
                site = url,
                pageTitle = await GetTitle(url),
                pageDecription = await GetDescription(url),
                YandexSQI = await YandexSQI(url),
                pageSpeedDesktop = await GetPageSpeedDesktop(url),
                date = DateTime.Now
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

        public async Task<string> GetPageSpeedDesktop(string url)
        {
            var adress = "http://profilink1.ru/seo/ru/www/" + url;
            var requester = new HttpRequester(adress);
            requester.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            requester.Headers["Accept-Charset"] = "utf-8";
            requester.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            var configuration = Configuration.Default.WithDefaultLoader(requesters: new[] { requester });
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var document = await context.OpenAsync(adress);
            System.Threading.Thread.Sleep(5000);
            var result = document.QuerySelector("#pagespeed_desktop > div > div.span7 > span.label.score-label.label-warning").TextContent;
            return await Delete(result);
        }

    }
}
