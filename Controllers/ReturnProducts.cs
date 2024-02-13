using Fish_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fish_Shop
{
    public class ReturnProducts : Controller
    {
        Fish_ShopContext db;
                
        public ReturnProducts(Fish_ShopContext context)
        {
            db = context;        
        }
        [Route("ReturnProducts")]
        public IActionResult Index()
        {
            var prodslist = db.Products.ToList();
            return View(prodslist); //Redirect("ReturnView");    //<-------- REDIRECT frim default Index to Main                        
        }
    }
}