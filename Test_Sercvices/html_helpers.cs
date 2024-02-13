using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
namespace Fish_Shop
{
	
	public static class html_helper1
	{
		public static HtmlString MyCreateList1(this IHtmlHelper html, string[] items)
		{
			string result = "<ul>";
			foreach(string item in items) 
			{
				result = $"{result}<li>{item}</li>";
			}
			result = $"{result}</ul>";
			return new HtmlString(result);
		}
		public static HtmlString MyCreateList2(this IHtmlHelper html, string[] items)
		{
			TagBuilder ul = new TagBuilder("ul");			
			foreach (string item in items)
			{
				TagBuilder li = new TagBuilder("li");
				li.InnerHtml.Append(item);
				ul.InnerHtml.AppendHtml(li);				
			}
			ul.Attributes.Add("class", "itemsList");
			using var writer = new StringWriter();
			ul.WriteTo(writer, HtmlEncoder.Default);
			return new HtmlString(writer.ToString());
		}
	}
}
