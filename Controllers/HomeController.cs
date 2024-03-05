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
    public enum enum_SortProducts { nameasc, namedesc, costasc, costdesc};
    public class HomeController : Controller
    {
        Fish_ShopContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Fish_ShopContext context)
        {
            db = context;        
            _logger = logger;
        }

        public async Task<IActionResult> Index(enum_SortProducts sortorder = enum_SortProducts.nameasc)
        {
            @ViewData["Title"] = "Главная";

            IQueryable<Product>? products = db.Products;
            products = sortorder switch
            {
                enum_SortProducts.nameasc => db.Products.OrderBy(p => p.Name),
                enum_SortProducts.namedesc => db.Products.OrderByDescending(p => p.Name),
                enum_SortProducts.costasc => db.Products.OrderBy(p => p.Cost),
                enum_SortProducts.costdesc => db.Products.OrderByDescending(p => p.Cost)
            };

            Console.WriteLine("User.Identity.IsAuthenticated = " + User.Identity.IsAuthenticated);
            Console.WriteLine("User.Identity.Name = " + User.Identity.Name);
            Console.WriteLine("User.Identity.AuthenticationType = " + User.Identity.AuthenticationType);
            Console.WriteLine("User.Identity.GetType = " + User.Identity.GetType);

            string userid;
            if (!User.Identity.IsAuthenticated) userid = db.Users.Where(u => u.UserName == "anonimus@anonimus.ru").Select(u => u.Id).FirstOrDefault();
            else userid = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
            Console.WriteLine("userid = " + userid);

            return View("Home_View", await products.ToListAsync());
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
