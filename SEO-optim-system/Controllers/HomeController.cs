using AngleSharp;
using AngleSharp.Network.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SEO_optim_system.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace SEO_optim_system.Controllers
{
    public class HomeController : Controller
    {

        private seoContext DbContext;
        public HomeController(seoContext context)
        {
            DbContext = context;
        }
        public IActionResult Index()
        {
            return View();
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
            ViewBag.Companies = DbContext.Companies.ToList();
            ViewBag.Employees = DbContext.Employees.ToList();
            ViewBag.Contracts = DbContext.Contracts.Include(c => c.Company).Include(c => c.Employee).ToList();
            return View();
        }
        public IActionResult Report()
        {
            ViewBag.Companies = DbContext.Companies.ToList();
            ViewBag.Employees = DbContext.Employees.ToList();
            ViewBag.Contracts = DbContext.Contracts.Include(c => c.Company).Include(c => c.Employee).ToList();
            ViewBag.Reports = DbContext.Reports.Include(c => c.Contract).Include(c => c.Employee).ToList();
            return View();
        }
        public IActionResult Directory()
        {
            return View();
        }

        // Company
        [HttpPost]
        public IActionResult AddCompany(Company model)
        {
            Company temp = new Company()
            {
                City = model.City,
                Country = model.Country,
                LPR = model.LPR,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber
            };
            DbContext.Companies.Add(temp);
            DbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult DeleteCompany(int? id)
        {
            if (id != null)
            {
                Company company = DbContext.Companies.FirstOrDefault(p => p.Id == id);
                if (company != null)
                {
                    DbContext.Companies.Remove(company);
                    DbContext.SaveChanges();
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPost]
        public JsonResult GetCompanyById(int id)
        {
            var temp = DbContext.Companies.FirstOrDefault(e => e.Id == id);
            if (temp == null)
                return Json(new { message = "error" });
            return Json(temp);
        }

        [HttpPost]
        public IActionResult UpdateCompany(Company model)
        {
            var temp = DbContext.Companies.FirstOrDefault(e => e.Id == model.Id);
            if (temp == null)
                return BadRequest();
            temp.Name = model.Name;
            temp.Country = model.Country;
            temp.City = model.City;
            temp.LPR = model.LPR;
            temp.PhoneNumber = model.PhoneNumber;
            DbContext.SaveChanges();
            return Ok();
        }

        // Contract
        [HttpPost]
        public IActionResult AddContract(Contract model)
        {
            Contract temp = new Contract()
            {
                Name = model.Name,
                Date = model.Date,
                Url = model.Url,
                Keywords = model.Keywords,
                GooglePoz = model.GooglePoz,
                YandexPoz = model.YandexPoz,
                OptimImg = model.OptimImg,
                OptimTag = model.OptimTag,
                OptimText = model.OptimText,
                CompanyId = model.CompanyId,
                EmployeeId = model.EmployeeId
            };
            DbContext.Contracts.Add(temp);
            DbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult DeleteContract(int? id)
        {
            if (id != null)
            {
                Contract contract = DbContext.Contracts.FirstOrDefault(p => p.Id == id);
                if (contract != null)
                {
                    DbContext.Contracts.Remove(contract);
                    DbContext.SaveChanges();
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPost]
        public JsonResult GetContractById(int id)
        {
            var temp = DbContext.Contracts.FirstOrDefault(e => e.Id == id);
            if (temp == null)
                return Json(new { message = "error" });
            return Json(temp);
        }

        [HttpPost]
        public IActionResult UpdateContract(Contract model)
        {
            var temp = DbContext.Contracts.FirstOrDefault(e => e.Id == model.Id);
            if (temp == null)
                return BadRequest();
            temp.Name = model.Name;
            temp.Date = model.Date;
            temp.Url = model.Url;
            temp.Keywords = model.Keywords;
            temp.GooglePoz = model.GooglePoz;
            temp.YandexPoz = model.YandexPoz;
            temp.OptimImg = model.OptimImg;
            temp.OptimTag = model.OptimTag;
            temp.OptimText = model.OptimText;
            temp.CompanyId = model.CompanyId;
            temp.EmployeeId = model.EmployeeId;
            DbContext.SaveChanges();
            return Ok();
        }

        // Employee
        [HttpPost]
        public IActionResult AddEmployee(Employee model)
        {
            Employee temp = new Employee()
            {
                FirstName = model.FirstName,
                Patronymic = model.Patronymic,
                SecondName = model.SecondName,
                Position = model.Position,
                Department = model.Department,
                PhoneNumber = model.PhoneNumber,
                Experience = model.Experience,
                Birthday = model.Birthday
            };
            DbContext.Employees.Add(temp);
            DbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id != null)
            {
                Employee employee = DbContext.Employees.FirstOrDefault(p => p.Id == id);
                if (employee != null)
                {
                    DbContext.Employees.Remove(employee);
                    DbContext.SaveChanges();
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee model)
        {
            var temp = DbContext.Employees.FirstOrDefault(e => e.Id == model.Id);
            if (temp == null)
                return BadRequest();
            temp.FirstName = model.FirstName;
            temp.Patronymic = model.Patronymic;
            temp.SecondName = model.SecondName;
            temp.Position = model.Position;
            temp.Department = model.Department;
            temp.PhoneNumber = model.PhoneNumber;
            temp.Experience = model.Experience;
            DbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public JsonResult GetEmployee(int id)
        {
            var temp = DbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (temp == null)
                return Json(new { message = "error" });
            return Json(temp);
        }

        // Report
        [HttpPost]
        public IActionResult AddReport(Report model)
        {
            Report temp = new Report()
            {
                Date = model.Date,
                Activity = model.Activity,
                ContractId = model.ContractId,
                EmployeeId = model.EmployeeId
            };
            DbContext.Reports.Add(temp);
            DbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult DeleteReport(int? id)
        {
            if (id != null)
            {
                Report report = DbContext.Reports.FirstOrDefault(p => p.Id == id);
                if (report != null)
                {
                    DbContext.Reports.Remove(report);
                    DbContext.SaveChanges();
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPost]
        public JsonResult GetReportById(int id)
        {
            var temp = DbContext.Reports.FirstOrDefault(e => e.Id == id);
            if (temp == null)
                return Json(new { message = "error" });
            return Json(temp);
        }

        [HttpPost]
        public IActionResult UpdateReport(Report model)
        {
            var temp = DbContext.Reports.FirstOrDefault(e => e.Id == model.Id);
            if (temp == null)
                return BadRequest();
            temp.Date = model.Date;
            temp.Activity = model.Activity;
            temp.ContractId = model.ContractId;
            temp.EmployeeId = model.EmployeeId;
            DbContext.SaveChanges();
            return Ok();
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
            requester.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            requester.Headers["Accept-Charset"] = "utf-8";
            requester.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
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
            requester.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*;q=0.8";
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
            //var adress = "https://be1.ru/stat/" + url;
            var adress = "http://e.megaindex.ru/analysis/" + url;
            var requester = new HttpRequester(adress);
            requester.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            requester.Headers["Accept-Charset"] = "utf-8";
            requester.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            var configuration = Configuration.Default.WithDefaultLoader(requesters: new[] { requester });
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var document = await context.OpenAsync(adress);
            //var result = document.QuerySelector("#set_description").TextContent;
            var result = document.QuerySelector("#set_description").TextContent;

            return await Delete(result);
        }

        public async Task<List<string>> GetSpamAndTrast(string url)
        {
            List<string> trtspm = new List<string>();
            var adress = "https://checktrust.ru/app.php?r=host/app/summary/basic&applicationKey=338bc2140502115cf718af016929edc6&host=" + url + "&parameterList=spam,trust";
            var requester = new HttpRequester(adress);
            requester.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*;q=0.8";
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

