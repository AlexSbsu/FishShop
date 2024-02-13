using Azure;
using Fish_Shop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fish_Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class NameAgeFormController : Controller
    {
        Fish_ShopContext db;
        public NameAgeFormController(Fish_ShopContext db2)
        {
            db = db2;
        }

        [HttpGet]
        public async Task Index()
        {
            string content = @"
	        <form method='post'>
	                <label>Name:</label><br />
	                    <input type='text' name='names' /><br />
                        <input type='text' name='names' /><br />                        
	                <label>Age:</label><br />
	                    <input type='number' name='age' /><br />
	                <input type='submit' value='Send' />
            </form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(content);
        }
        //[HttpPost]
        //public string Index(string? name, int? age) => $"name={Request.Form["name"]}, age={Request.Form["age"]}";
        //public string Index(string? name, int? age){return $"name={Request.Form["name"]}, age={Request.Form["age"]}";}
        [HttpPost]
        public string Index(string[] names, int age)
        {
            //return $"name1={Request.Form["names[0]"]},names2={Request.Form["names[1]"]}, age={Request.Form["age"]}";
            /*
             string result = "";
             foreach (string name in names) result=$"{result} {name}";
             return $"names = {result}, age={Request.Form["age"]}";
            */
            return $"POSTED";
        }


        //public string form(string name, int age)
        //{
        /*
        User user = new User() { Name=name, Age=age};
        db.Users.Add(user);
        db.SaveChanges();
        */
        //return $"name={name} age={age}";

        //}

        // GET: NameAgeForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NameAgeForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NameAgeForm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NameAgeForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NameAgeForm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NameAgeForm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NameAgeForm/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
