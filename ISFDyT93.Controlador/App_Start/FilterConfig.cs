using System.Web;
using System.Web.Mvc;

namespace ISFDyT93.Controlador
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
