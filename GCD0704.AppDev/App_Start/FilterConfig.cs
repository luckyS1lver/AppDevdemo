using System.Web;
using System.Web.Mvc;

namespace GCD0704.AppDev
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
