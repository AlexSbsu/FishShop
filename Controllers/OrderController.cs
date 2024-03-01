using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fish_Shop.Controllers
{
    public class OrderController : Controller
    {
        Fish_ShopContext db;
        
        public OrderController(Fish_ShopContext dbcontext)
        { 
            db = dbcontext;
        }

        public IActionResult Order_Complete()//([FromBody] string[] orderslist)
        {
            return View("Order_Complete");
        }

        [HttpPost]
        public IActionResult Order_Create([FromBody] FormOrder fo)
        {            
            Console.WriteLine("fo = " + fo);         
            Console.WriteLine("fo.Comment=" + fo.Comment);            
            Console.WriteLine("fo.TotalCost =" + fo.TotalCost  );
            foreach(var bi in fo.BasketItems)
            {
                Console.WriteLine("fo.ProductId=" + bi.ProductId);
                Console.WriteLine("fo.Cost=" + bi.Cost);
                Console.WriteLine("fo.Amount=" + bi.Amount);
                Console.WriteLine("fo.FullCost=" + bi.FullCost);
            }

            
            

            return StatusCode(200);
        }
        [HttpPost]
        public JsonResult test2([FromBody] string name)
        {
            Console.WriteLine("name = " + name);
            return Json(new { Name = name, DateTime = DateTime.Now.ToShortDateString() });
        }
    }
}
