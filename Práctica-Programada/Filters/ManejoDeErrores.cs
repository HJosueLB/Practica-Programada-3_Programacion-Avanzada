using System;
using System.Web;
using System.Web.Mvc;

namespace Práctica_Programada.Filters
{
    public class ManejoDeErrores : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            var controller = (string)filterContext.RouteData.Values["controller"];
            var action = (string)filterContext.RouteData.Values["action"];

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error500.cshtml"
            };

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
