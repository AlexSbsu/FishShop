using Microsoft.AspNetCore.Mvc;

namespace Fish_Shop
{
	public class ReturnView2 : Controller
	{
		public ActionResult Index()
		{
			User tom = new User { Name="Tom", Age=99 };
			return View(tom);
		}
	}
}
