using GCD0704.AppDev.Models;
using System.Collections.Generic;

namespace GCD0704.AppDev.ViewModels
{
	public class TodoCategoriesViewModel
	{
		public Todo Todo { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}