using Fish_Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Fish_Shop
{ 
    [Route("ReturnView")]
	public class ReturnViewController : Controller
    {
        // GET: ReturnView
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Message"] = "This ViewData value of 'Message'";
			ViewData["mylist"] = new List<string> { "string1", "string2", "string3" };
			
            ViewBag.mystring = "ViewBag.mystring value";
			ViewBag.mylist = new List<string> { "Tom", "Bob", "Vanessa" };

            //string[] mystringarray = new string[] { "Tom", "Bob", "Vanessa" };
            string mystringarray = "My custom string for Model";
			return View((object)mystringarray);
        }
        [HttpPost]
        public ActionResult Index([FromForm]string username, [FromForm] int age,
								[FromQuery] bool isHappy, //!!!to be ignoired as from query
                                [FromForm] string color, [FromForm] string language)
        {
            List<string> formparams = new List<string>();
            formparams.Add($"User Name = {username}");
			formparams.Add($"User Age = {age}");
			formparams.Add($"Is Happy = {isHappy}");
			formparams.Add($"Color = {color}");
			formparams.Add($"Language = {language}");

			return View("Index_Submitted", formparams);
        }
        public ActionResult Index1()
        {
            return View();
        }

        [Route("Index2")]
		[Route("Index99")]
		public string Index2()
		{
			return $"Returned string from method based on route-attribute" +
                    $" controller={RouteData.Values["controller"]}" +
                    $", method={RouteData.Values["action"]}" +
                    $", path = {Request.Path}";
		}
				              
    }
}
