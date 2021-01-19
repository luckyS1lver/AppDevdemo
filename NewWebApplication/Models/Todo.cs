using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewWebApplication.Models
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