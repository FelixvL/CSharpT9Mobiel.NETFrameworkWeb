using System.Web;
using System.Web.Mvc;

namespace Les1SMSWebForm.NETFrameworkCSharp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
