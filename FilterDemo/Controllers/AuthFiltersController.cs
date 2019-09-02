using FilterDemo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterDemo.Controllers
{
	public class AuthFiltersController : Controller
	{
		// GET: AuthFilters
		public ActionResult Index()
		{
			return View();
		}

		//[Authorize(Users ="a,bb,ccc")]
		[Authorize]
		public ActionResult Welcome()
		{
			ViewBag.Message = "普通已授权页面";
			ViewBag.UserName = "ABC";
			return View();
		}

		/// <summary>
		/// 管理员页面
		/// </summary>
		/// <returns></returns>
		[UserAuthorize(AuthorizationFailView = "Error")]   
		public ActionResult AdminUser()
		{
			ViewBag.Message = "管理员页面";
			return View("Welcome");
		}

		/// <summary>
		/// 高级会员页面
		/// </summary>
		/// <returns></returns>
		[UserAuthorize(AuthorizationFailView="Error")]
		public ActionResult SeniorUser()
		{
			ViewBag.Message = "高级会员页面";
			return View("Welcome");
		}

		/// <summary>
		/// 游客页面
		/// </summary>
		/// <returns></returns>
		[UserAuthorize(AuthorizationFailView = "Error")]
		public ActionResult JuniorUser()
		{
			ViewBag.Message = "初级会员页面";
			return View("Welcome");
		}
    }
}