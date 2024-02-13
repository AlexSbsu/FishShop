using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Fish_Shop.Controllers
{
    public class ReturnResultController : Controller
    {
        readonly ITimeService itemiserv;
        public ReturnResultController(ITimeService its)
        {
            itemiserv = its;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Controller : {context.Controller.ToString()}");
            //base.OnActionExecuting(context);
        }
        
        //public string Index() { return Content("From ReturnResultController as string"); }
        //public IActionResult Index() { return Content("From ReturnResultController as Content of ActionResult"); }
        //public JsonResult Index() { return Json("From ReturnResultController as Json of JsonResult"); }
        /*
        public IActionResult Index()
        {
            var pers = new person("bobbby",30);
            var jsonoptions = new JsonSerializerOptions
            {PropertyNameCaseInsensitive = true,WriteIndented = true};
            return Json(pers,jsonoptions);
        }
        */
        //-----------------------------------------
        //public IActionResult Index() { return Redirect("~/");}
        //public IActionResult Index() { return RedirectPermanent("~/"); }
        //public IActionResult Index() { return LocalRedirect("~/"); }
        //public IActionResult Index() { return Redirect("https://www.google.com"); }
        //-----------------------------------------
        //public IActionResult Index() { return RedirectToAction("redirect","Home"); }
        //-----------------------------------------
        //public IActionResult Index() { return RedirectToAction("localredirect"); }
        //public string localredirect() { return ("REDIRECTED locally"); }
        //-----------------------------------------
        //public IActionResult Index() { return RedirectToAction("redirectwithparam", "Home", new { param="remoteparam!!!"}); }
        //-----------------------------------------RETURN FILES
        /*
        public IActionResult Index() 
        {
            //string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/textfile1.txt");
            string file_path = @"d:/C#_Project/Fish_Shop1/Controllers/Files/textfile1.txt";
            string file_type = "text/plain";
            string file_name = "textfile1.txt";
            return PhysicalFile(string file_path, file_type, file_name);
        }
        public IActionResult Index()
        {            
            return File(@"Files/textfile1.txt", "text/plain", "textfile1.txt");
        }
        */
        //----------------------------------------SERVICE Time/Date Services
        public IActionResult Index([FromServices] IDateService dateservice)
        {
            return Content($"Time = {itemiserv.GetTime}\nDateNow = {dateservice.GetDateNow}");			
        }
        public record class person(string name, int age);

    }
}
