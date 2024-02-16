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
