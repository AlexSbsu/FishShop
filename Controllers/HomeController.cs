using Fish_Shop.Data;
using Fish_Shop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using static Azure.Core.HttpHeader;

namespace Fish_Shop
{
    public enum sortProducts { nameasc, namedesc, costasc, costdesc};
    public class HomeController : Controller
    {
        Fish_ShopContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Fish_ShopContext context)
        {
            db = context;        
            _logger = logger;
        }
        
        public async Task<IActionResult> Index(sortProducts sortorder = sortProducts.nameasc)
        {
            @ViewData["Title"] = "Главная";

            //ViewBag.["namesort"] = sortproduct == sortProducts.nameasc ? sortProducts.namedesc : sortProducts.nameasc;
            //ViewData["costsort"] = sortproduct == sortProducts.costasc ? sortProducts.costdesc : sortProducts.costasc;

            IQueryable<Product>? products = db.Products;
            products = sortorder switch
            {
                    sortProducts.nameasc  => db.Products.OrderBy(p => p.Name),
                    sortProducts.namedesc => db.Products.OrderByDescending(p => p.Name),
                    sortProducts.costasc  => db.Products.OrderBy(p => p.Cost),
                    sortProducts.costdesc => db.Products.OrderByDescending(p => p.Cost)
            };
                
                return View("main", await products.ToListAsync()); //Redirect("ReturnView");    //<-------- REDIRECT frim default Index to Main                        
        }

        public IActionResult About()
        {
            return View();
        }

        [Authorize]
        [Route("authcheck")]
        public string authcheck()
        {            
            return $"YOU ARE AUTHORIZED";
        }
        public string methmyparams(string param1, string param2)
        {
            return $"parameter1 : {param1}\nparameter2 : {param2}";
        }
        public record class mytypecl
        { 
            public string param1;
            public string param2;
        }
        public record class mytyper(string param1, string param2);
        
        //https://localhost:7108/methmytype?param1=PARAMETER1value&param2=PARAMETER2value
        public string methmytype1(mytyper mt)
        { return $"Result:\nparameter1 : {mt.param1}\nparameter2 : {mt.param2}"; }
        
        //https://localhost:7108/methmytype?st=PARAMETER1value&st=PARAMETER2value
        public string methmytype2(string[] st)
        {
            string r = "";
            foreach (var s in st) r = $"{r}\n{s}";
            return r; 
        }

        //https://localhost:7108/?[0].param1=PARAMETER1value&[0].param2=PARAMETER2value
        public string methmytype3(mytyper[] mytcl)
        {
            string r = "";
            foreach (var s in mytcl) r = $"Result:\n {r}\n{s.param1} - {s.param1}";
            return r;
        }

        //https://localhost:7108/?dic[key1]=value1&dic[key2]=value2
        public string methmytype4(Dictionary<string,string> dic)
        {
            string r = "";
            foreach (var d in dic) r = $"Result:\n {r}\n{d.Key} - {d.Value}";
            return r;
        }

        //https://localhost:7108/?param1=Param1Value&param2=Param2Value
        public string methmytype()
        {            
            return $"Result:\n Param1:{Request.Query["param1"]}\n Param2:{Request.Query["param2"]}";
        }
        public string redirect()
        {
            return $"REDIRECTED to home/redirect";
        }
        public string redirectwithparam(string param)
        {
            return $"REDIRECTED to home/redirect with param={param}";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
