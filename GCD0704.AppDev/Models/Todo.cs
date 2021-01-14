using System;
using System.ComponentModel.DataAnnotations;

namespace GCD0704.AppDev.Models
{
	public class Todo
	{

		public int Id { get; set; }
		[Required(ErrorMessage = "Name should not be empty")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Description must be described")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Due Date must not be empty")]
		public DateTime DueDate { get; set; }

	}
}