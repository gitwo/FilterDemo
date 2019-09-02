using FilterDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FilterDemo.Controllers
{
	public class AccountController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Login()
		{			
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginViewModel model)
		{
			if (model.UserName.Trim().Equals(model.password.Trim(), StringComparison.CurrentCultureIgnoreCase))
			{
				if (model.RememberMe)
				{
					FormsAuthentication.SetAuthCookie(model.UserName, true);//cookie 有效期为配置时长
				}
				else
				{
					FormsAuthentication.SetAuthCookie(model.UserName, false);//会话cookie
				}
				return RedirectToAction("Welcome", "AuthFilters");
			}
			else
			{
				return View(model);
			}			
		}

		public ActionResult Logout()
		{
			return RedirectToAction("Login");
		}
	}
}