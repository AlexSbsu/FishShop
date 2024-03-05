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
    //public enum enum_SortProducts { "nameasc", "namedesc", "costasc", "costdesc"};
    public enum enum_FilterProducts { filter_all, filter_fish, filter_plant, filter_tool };
    public class HomeTestController : Controller
    {
        Fish_ShopContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeTestController(ILogger<HomeController> logger, Fish_ShopContext context)
        {
            db = context;        
            _logger = logger;
        }

        //public async Task<IActionResult> Index(enum_FilterProducts filterprods = enum_FilterProducts.all, enum_SortProducts sortorder = enum_SortProducts.nameasc)
        //public async Task<IActionResult> Index([FromQuery] string[] filters )
        public async Task<IActionResult> Index()
        {
            @ViewData["Title"] = "Главная";

            //foreach (string ftr in filters){Console.WriteLine("filter : " + ftr);}
            //IQueryable<Product>? products = db.Products.Join(db.Categories, p => p.CategoryId, c => c.Id, (p, c) => new { ProdId = p.Id, CategoryName = c.Name}).ToList();
            //var prod_categ = db.Products.Join(db.Categories, p => p.CategoryId, c => c.Id, (p, c) => new { ProdId = p.Id, CategoryName = c.Name }).Where(p => p.CategoryName.Contains(prodset.ToList()));

            /*
                    var products = db.Products.Where(p => basketprodlist.Contains(p.Id)).OrderBy(p => p.Name);

                var prod_categ = db.Products.
                IQueryable<Product>? products = db.Products
                    select p.id from prod_categ where prod_categ.Catgory.Name in ()
                    select p.id from Products where 

                    var arrayOfInts = selected.Select(s => Convert.ToInt32(s.Value)).ToArray();
                    using (var db = new DWSEntities())
                    {
                    var muscles = db.Muscles.Where(m => arrayOfInts.Contains((int)m.MainMusleGroupID))
                                            .Select(m => new { m.MusleName, m.ID }).Take(40);
               */
            /*string[] prodset;
            products = prodset[0] switch
            {
                "nameasc"  => db.Products.OrderBy(p => p.Name),
                "namedesc" => db.Products.OrderByDescending(p => p.Name),
                "costasc"  => db.Products.OrderBy(p => p.Cost),
                "costdesc" => db.Products.OrderByDescending(p => p.Cost)
            };                        
            */

            string userid;
            if (!User.Identity.IsAuthenticated) userid = db.Users.Where(u => u.UserName == "anonimus@anonimus.ru").Select(u => u.Id).FirstOrDefault();
            else userid = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
            
            return View("Index", await db.Products.ToListAsync());
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
