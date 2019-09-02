using FilterDemo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterDemo.Controllers
{
	public class ExceptionController : Controller
	{
		[ExceptionFilters(View = "Exception")]
		public ActionResult Index()
		{
			throw new NullReferenceException("测试抛出异常！");
		}

		//[HandleError(ExceptionType = typeof(FormatException), View = "ExceptionDetails")]
		[ExceptionFilters(View = "ExceptionDetails")]
		public ActionResult Details()
		{
			int i = int.Parse("hello,world!");
			return View();
		}
	}
}