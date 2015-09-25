using System.Web.Mvc;
using Hooker.WebApi.Filters;

namespace Hooker.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new TraceActionAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
