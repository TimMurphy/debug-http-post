using System.Web.Mvc;
using Anotar.NLog;

namespace Hooker.WebApi.Filters
{
    public class TraceActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // ReSharper disable once UseStringInterpolation
            LogTo.Trace(() => string.Format(
                "{0} will be handled by {1}Controller.{2}({3})", 
                filterContext.RequestContext.HttpContext.Request.Url, 
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, 
                filterContext.ActionDescriptor.ActionName,
                string.Join(", ", filterContext.ActionParameters.Keys)));
        }
    }
}