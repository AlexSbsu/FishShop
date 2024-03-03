using Fish_Shop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using static Azure.Core.HttpHeader;
using Microsoft.AspNetCore.Identity;
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
                
        public IActionResult Order_Create([FromBody] FormOrder fo)
        {            
            Console.WriteLine("fo = " + fo);         
            Console.WriteLine("fo.Comment=" + fo.Comment);            
            Console.WriteLine("fo.TotalCost =" + fo.TotalCost);
            foreach(var bi in fo.BasketItems)
            {
                Console.WriteLine("fo.ProductId=" + bi.ProductId);
                Console.WriteLine("fo.Name=" + bi.Name);
                Console.WriteLine("fo.Cost=" + bi.Cost);
                Console.WriteLine("fo.Amount=" + bi.Amount);
                Console.WriteLine("fo.FullCost=" + bi.FullCost);
            }

            string userid="";
            string username="";
            if (!User.Identity.IsAuthenticated)
            {
                userid = db.Users.Where(u => u.UserName == "anonimus@anonimus.ru").Select(u => u.Id).FirstOrDefault();
                username = "anonimus";
            }
            else
            {
                userid = db.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault();
                username = User.Identity.Name;
            }                

            Order order = new Order();
            order.Comment = fo.Comment;
            order.TotalCost = fo.TotalCost;
            order.Number = "Order_" + DateTime.Now.Date.ToString("yyyyMMdd") + "_" + username;
            order.UserId = userid;

            List<OrderItem> basketitemslist = new List<OrderItem>();

            foreach (var bi in fo.BasketItems)
            {
                basketitemslist.Add(new OrderItem { ProductId = bi.ProductId, Name = bi.Name, Amount = bi.Amount, Cost = bi.Cost, FullCost = bi.FullCost });              
            }

            order.OrderItems = basketitemslist;
            db.Orders.Add(order);
            db.SaveChanges();

            Console.WriteLine("order.Id =" + order.Id);

            return Content(order.Id);            
        }
        public async Task<IActionResult> Order_Complete([FromQuery] string orderid)//([FromBody] string[] orderslist)
        {
            var orderinf = db.Orders.Where(o => o.Id == orderid).Include(o => o.OrderItems);
            //var orderinf = db.Orders.Where(o => o.Number == order.Number);

            //Console.WriteLine("order id received = " + orderid);
            //Console.WriteLine("orderinf.number = " + orderinf.Number);
            //Console.WriteLine("orderinf.Id = " + orderinf.Id);
            //Console.WriteLine("orderinf.Id = " + orderinf.ToString());

            return View("Order_Complete",  orderinf);
        }
    }
}
