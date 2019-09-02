using FilterDemo.DataBase;
using FilterDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterDemo.Extensions
{
	/// <summary>
	/// Action权限过滤
	/// </summary>
	public class ActionFilters : ActionFilterAttribute
	{
		public string ActionName { get; set; }   //控制器名
												 //public string Area { get; set; }   //区域名
		public string Roles { get; set; }  //可以操作当前Action的角色Id集合

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			string userName = filterContext.HttpContext.User.Identity.Name;
			User user = SampleData.users.Find(u => u.UserName == userName);

			if (user != null)
			{
				string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
				string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();
				if (ActionName == null) ActionName = actionName;

				RoleWithControllerAction roleWithControllerAction = SampleData.roleWithControllerAndAction.Find(r => r.ControllerName.ToLower() == controllerName &&
	 controllerName.ToLower() == ActionName.ToLower());
				if (roleWithControllerAction != null)
				{
					this.Roles = roleWithControllerAction.RoleIds;     //有权限操作当前控制器和Action的角色id
				}
				if (!string.IsNullOrEmpty(Roles))
				{
					Role role = SampleData.roles.Find(r => r.Id == user.RoleId);
					foreach (string roleid in Roles.Split(','))
					{
						if (role.Id.ToString() == roleid)
							return;   //return就说明有权限
					}
				}
				filterContext.Result = new EmptyResult();   //请求失败输出空结果
				HttpContext.Current.Response.Write("对不起，你没有权限！");   //打出提示文字
																	//return;
			}
			else
			{
				filterContext.Result = new EmptyResult();
				HttpContext.Current.Response.Write("对不起，请先登录！");
			}
			//base.OnActionExecuting(filterContext);

		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			base.OnResultExecuting(filterContext);
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			base.OnResultExecuted(filterContext);
		}
	}
}