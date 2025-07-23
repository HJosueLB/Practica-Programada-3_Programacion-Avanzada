using System.Web;
using System.Web.Mvc;
using Práctica_Programada.Filters;

namespace Práctica_Programada
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ManejoDeErrores());
        }
    }
}
