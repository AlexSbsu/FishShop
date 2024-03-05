using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Fish_Shop
{
    public class BasketController : Controller
    {        
        Fish_ShopContext db;

        //private readonly ILogger<HomeController> _logger;

        public BasketController(ILogger<HomeController> logger, Fish_ShopContext context)
        {
            db = context;        
            //_logger = logger;
        }
        public async Task<IActionResult> Index(string[] basketprodlist)
        {
            //Cookies
            
            string? prodsTobuycookie;
            if (Request.Cookies.ContainsKey("prodsTobuycookie"))
                prodsTobuycookie = Request.Cookies["prodsTobuycookie"];
            else
            {
                prodsTobuycookie = "No prodsTobuycookie cookies found";
                Response.Cookies.Append("prodsTobuycookie","empty");
                //prodsTobuycookie = Request.Cookies["prodsTobuycookie"];
            } 
            Console.WriteLine("Request.Cookies prodsTobuycookie = " + Request.Cookies["prodsTobuycookie"]);
            Console.WriteLine("Request.Cookies All Cookies : " + Request.Cookies.ToString());
            Console.WriteLine("Request.Cookies.Count().ToString(); =" + Request.Cookies.Count().ToString());
            Console.WriteLine("Response.Cookies.Count().ToString(); =" + Response.Cookies.ToString());
            
            if (basketprodlist == null) basketprodlist[0] = "emty";
            Console.WriteLine("basketProdList = " + basketprodlist);

            Console.WriteLine("string[] basketprodlist :");
            foreach(var p in basketprodlist) Console.WriteLine("prod ID = " + p);
            
            var products = db.Products.Where(p => basketprodlist.Contains(p.Id)).OrderBy(p=>p.Name);

            return View("Basket_View_Step1", await products.ToListAsync());
        }
    }
}