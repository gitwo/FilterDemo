using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace FilterDemo
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//  �����֤ʱ��ί�� Occurs when a security module has established the identity of the user.
			//  �����������ã��ᵼ��һ�������ε��ã�Ӧʹ��Authorize���������棬��isAuthorized = base.AuthorizeCore(httpContext)��ʱ����
			//   ����Ҫ����ҳ��Ҳ��Ҫ����ʱ��Ӧʹ��ActionFilterAttribute,filters.Add(new LoadCustomAuthTicket());
			this.PostAuthenticateRequest += new EventHandler(Application_PostAuthenticateRequest);
		}

		protected void Application_PostAuthenticateRequest(object sender,EventArgs e)
		{
			HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			if (authCookie != null)
			{
				FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
				var identity = new GenericIdentity(authTicket.Name, "Forms");
				var principal = new GenericPrincipal(identity, new string[] { });
				Context.User = principal;
			}
			
		}
	}

	/**
	 public class LoadCustomAuthTicket : ActionFilterAttribute, IAuthenticationFilter
{
    public void OnAuthentication(AuthenticationContext filterContext)
    {
        if (!filterContext.Principal.Identity.IsAuthenticated)
            return;

        HttpCookie authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

        if (authCookie == null)
            return;

        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        var identity = new GenericIdentity(authTicket.Name, "Forms");
        var principal = new GenericPrincipal(identity, new string[] { });

        // Make sure the Principal's are in sync. see: https://www.hanselman.com/blog/SystemThreadingThreadCurrentPrincipalVsSystemWebHttpContextCurrentUserOrWhyFormsAuthenticationCanBeSubtle.aspx
        filterContext.Principal = filterContext.HttpContext.User = System.Threading.Thread.CurrentPrincipal = principal;

    }
    public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
    {
        //This method is responsible for validating the current principal and permitting the execution of the current action/request.
        //Here you should validate if the current principle is valid / permitted to invoke the current action. (However I would place this logic to an authorization filter)
        //filterContext.Result = new RedirectToRouteResult("CustomErrorPage",null);
    }
}
	 */
}
