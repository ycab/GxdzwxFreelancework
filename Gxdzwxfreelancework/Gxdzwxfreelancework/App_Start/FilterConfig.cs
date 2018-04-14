using System.Web;
using System.Web.Mvc;
using Gxdzwxfreelancework.Filter;
namespace Gxdzwxfreelancework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new IsUser());
        }
    }
}