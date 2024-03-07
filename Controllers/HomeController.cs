using Fish_Shop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Net;
using static Azure.Core.HttpHeader;
using static NuGet.Packaging.PackagingConstants;

namespace Fish_Shop
{    
    public class HomeController : Controller
    {
        Fish_ShopContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Fish_ShopContext context)
        {
            db = context;        
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            @ViewData["Title"] = "Главная";

            Console.WriteLine("!!!! ENTERED HOME Index() !!!!");

            return View("Index", await db.Products.OrderBy(p => p.Name).ToListAsync());
        }

        public async Task<IActionResult> Products_List([FromBody] string?[] ord_rule)
        {
            Console.WriteLine("!!!! ENTERED Partial1() !!!!");
            foreach (string s in ord_rule) Console.WriteLine("ord_rule = " + s);

            if (ord_rule == null) ord_rule = new string[] { "nameasc", "category_filter_all" };

            IQueryable<Product> prods;
            string sort_type = ord_rule[0];
            string?[] filters = new string[ord_rule.Length - 1];

            if (ord_rule[1] == "category_filter_all") prods = db.Products;
            else
            {
                for (int i = 1; i < ord_rule.Length; i++)
                {
                    filters[i - 1] = ord_rule[i] switch
                    {
                        "category_filter_fish" => "Рыба",
                        "category_filter_plant" => "Растение",
                        "category_filter_tool" => "Оборудование"
                    };
                }
                prods = db.Products.Where(p => filters.Contains(p.CategoryId));
                foreach (string s in filters) Console.WriteLine("filters = " + s);
                foreach (var p in prods) Console.WriteLine("filtere prods = " + p.Name + " " + p.CategoryId);
            }

            prods = sort_type switch
            {
                "nameasc" => prods.OrderBy(p => p.Name),
                "namedesc" => prods.OrderByDescending(p => p.Name),
                "costasc" => prods.OrderBy(p => p.Cost),
                "costdesc" => prods.OrderByDescending(p => p.Cost)
            };

            string userid;
            if (!User.Identity.IsAuthenticated) userid = db.Users.Where(u => u.UserName == "anonimus@anonimus.ru").Select(u => u.Id).FirstOrDefault();
            else userid = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();

            Console.WriteLine("ord_rule = " + ord_rule);

            return PartialView("ProductsList_PartialView", await prods.ToListAsync());
        }

        public IActionResult About()
        {
            return View();
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
