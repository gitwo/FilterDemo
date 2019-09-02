using FilterDemo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterDemo.Controllers
{
	public class ActionFiltersController : Controller
	{
		[ActionFilters]
		public ActionResult Index()
		{
			return View();
		}

		[ActionFilters(ActionName = "Index")]
		public ActionResult Details()
		{
			return View();
		}

		[ActionFilters]
		public ActionResult Test()
		{
			return View();
		}
	}
}