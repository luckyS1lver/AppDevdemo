using System.ComponentModel.DataAnnotations;

namespace GCD0704.AppDev.Models
{
	public class Category
	{
		public int Id { get; set; }
		[Required(ErrorMessage = ("Category Name must not be empty !!!"))]
		public string Name { get; set; }
	}
}