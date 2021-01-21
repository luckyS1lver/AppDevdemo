using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GCD0704.AppDev.Models
{
    public class TodoUser
    {
		[Key]
		public int Id { get; set; }
		[Required]
		public int TodoId { get; set; }
		public Todo Todo { get; set; }
		[Required]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
	}
}