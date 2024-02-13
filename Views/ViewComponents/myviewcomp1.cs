using Microsoft.AspNetCore.Mvc;

namespace Fish_Shop
{
	public class myviewcomp1 : ViewComponent
	{
		public string Invoke()
		{
			return $"String from myviewcomp1";
		}
	}
	public class myviewcompAsync1 : ViewComponent
	{
		public async Task<string> InvokeAsync(string param)
		{
			using (StreamReader reader = new StreamReader("Controllers/Files/myviewcompAsync1.txt"))
			return await reader.ReadToEndAsync() + param;
		}
	}
	public class myviewcompAsync2 : ViewComponent
	{
		public IViewComponentResult Invoke()
		{			
			return Content("From myviewcompAsync2 date DateTime.Now as string:" + DateTime.Now.ToString());
		}
	}
	public class myviewcompAsync3 : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			string? viewstr = "aaaa";//ViewComponentContext.ToString();
			return View("myviewcompAsync3_view",viewstr);
		}
	}
}
