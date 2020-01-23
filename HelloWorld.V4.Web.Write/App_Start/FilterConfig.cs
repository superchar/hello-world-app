using System.Web;
using System.Web.Mvc;

namespace HelloWorld.V4.Web.Write
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
