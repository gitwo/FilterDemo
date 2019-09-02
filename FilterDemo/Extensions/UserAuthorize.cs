using FilterDemo.DataBase;
using FilterDemo.Models;
using System.Web;
using System.Web.Mvc;

namespace FilterDemo.Extensions
{
	/// <summary>
	/// 自定义用户授权
	/// </summary>
	public class UserAuthorize : AuthorizeAttribute
	{
		/// <summary>
		/// 授权失败时呈现的视图
		/// </summary>
		public string AuthorizationFailView { get; set; }

		/// <summary>
		/// 请求授权时执行
		/// </summary>
		/// <param name="httpContext"></param>
		/// <returns></returns>
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			//获取url请求中的controller和action
			string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
			string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();
			//获取用以下方式
			controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
			actionName = filterContext.ActionDescriptor.ActionName;

			//根据请求的controller和action去查询可以被哪些角色操作
			RoleWithControllerAction roleWithControllerAction = SampleData.roleWithControllerAndAction.Find(r => r.ControllerName.ToLower() == controllerName.ToLower() && actionName.ToLower() == actionName.ToLower());
			if (roleWithControllerAction != null)
			{
				this.Roles = roleWithControllerAction.RoleIds;
			}

			base.OnAuthorization(filterContext);
		}

		/// <summary>
		/// 自定义授权检查
		/// </summary>
		/// <param name="httpContext"></param>
		/// <returns>false 失败</returns>
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			if (httpContext.User.Identity.IsAuthenticated)
			{
				string userName = httpContext.User.Identity.Name;
				User user = SampleData.users.Find(u => u.UserName == userName);

				if (user != null)
				{
					Role role = SampleData.roles.Find(r => r.Id == user.RoleId);
					foreach (string roleId in Roles.Split(','))
					{
						if (role.Id.ToString() == roleId)
						{
							return true;
						}
					}
					return false;
				}

				return false;
			}

			return false;
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Result = new ViewResult { ViewName = AuthorizationFailView };
			//base.HandleUnauthorizedRequest(filterContext);
		}

		protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
		{

			return base.OnCacheAuthorization(httpContext);
		}
	}
}