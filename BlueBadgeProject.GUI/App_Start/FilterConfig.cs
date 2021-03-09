using BlueBadgeProject.GUI.Models;
using System.Web;
using System.Web.Mvc;

namespace BlueBadgeProject.GUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new WebApiAuthorize());
        }
    }
}
