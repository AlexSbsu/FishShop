using Microsoft.AspNetCore.Mvc;


namespace Fish_Shop
{
    public class BasketController : Controller
    {
        string? _basketProdList;
        //[HttpPost]        
        public IActionResult Index(string[] basketprodlist)
        {

            //Cookies
            /*
            string? prodsTobuycookie;
            if (Request.Cookies.ContainsKey("prodsTobuycookie"))
                prodsTobuycookie = Request.Cookies["prodsTobuycookie"];
            else
            {
                prodsTobuycookie = "No prodsTobuycookie cookies found";
                Response.Cookies.Append("prodsTobuycookie","empty");
                prodsTobuycookie = Request.Cookies["prodsTobuycookie"];
            } 
            Console.WriteLine("prodsTobuycookie = " + Request.Cookies["prodsTobuycookie"]);
            Console.WriteLine("All Cookies =" + Request.Cookies.ToString());
            Console.WriteLine("Request.Cookies.Count().ToString(); =" + Request.Cookies.Count().ToString());
            Console.WriteLine("Response.Cookies.Count().ToString(); =" + Response.Cookies.ToString());
            */

            if (basketprodlist == null) basketprodlist[0] = "emty";

            Console.WriteLine("basketProdList = " + basketprodlist);
            
            return View(basketprodlist);
        }

        //[HttpGet]
        public IActionResult Index2()
        {            
            Console.WriteLine("basketProdList = " + _basketProdList);

            return View("Index", _basketProdList);
        }


    }
}
