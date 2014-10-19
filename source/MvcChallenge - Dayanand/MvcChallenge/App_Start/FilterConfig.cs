using System.Web.Mvc;
using MvcChallenge.Filters;

namespace MvcChallenge
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ErrorLoggerAttribute());
        }
    }
}