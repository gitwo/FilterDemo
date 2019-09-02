using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterDemo.Extensions
{
	public class ExceptionFilters : HandleErrorAttribute
	{
		public override void OnException(ExceptionContext filterContext)
		{
			if (!filterContext.ExceptionHandled)
			{
				string controllerName = filterContext.RouteData.Values["controller"].ToString();
				string actionName = filterContext.RouteData.Values["action"].ToString();

				HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

				ViewResult result = new ViewResult
				{
					ViewName = this.View,
					ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
				};
				filterContext.Result = result;
				filterContext.ExceptionHandled = true;
			}
			//base.OnException(filterContext);
		}
	}
}