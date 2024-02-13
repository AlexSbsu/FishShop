using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Fish_Shop
{
	public class ReturnView3 : Controller
	{
		// GET: ReturnView3
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(Person person)
		{
			if (ModelState.IsValid)
				return Content($"{person.Name} - {person.Age}");
			else
			{
				string errorMessages = "";

				foreach (var item in ModelState)
				{
					if (item.Value.ValidationState == ModelValidationState.Invalid)
					{
						errorMessages = $"{errorMessages}\nОшибки для свойства {item.Key}:\n";
						foreach (var err in item.Value.Errors)
						{
							errorMessages = $"{errorMessages}{err.ErrorMessage}\n";
						}
					}
				}
				return Content(errorMessages);
			}			
		}
		[Authorize]
        public string authcheck()
        {
            return $"YOU ARE AUTHORIZED in ReturnView3 controller";
        }

    }
}
