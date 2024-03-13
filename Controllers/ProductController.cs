using Microsoft.AspNetCore.Mvc;

namespace Fish_Shop.Controllers
{
    public class ProductController : Controller
    {
        Fish_ShopContext db;
                
        public ProductController(Fish_ShopContext context)
        {
            db = context;            
        }

        public IActionResult Product([FromQuery]string productid)
        {
            Product product = db.Products.FirstOrDefault(p=>p.Id==productid);
            
            return View("Product_View", product);
        }
    }
}
