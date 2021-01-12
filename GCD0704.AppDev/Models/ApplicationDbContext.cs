﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GCD0704.AppDev.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
				: base("DefaultConnection", throwIfV1Schema: false)
		{
		}
		public DbSet<Todo> Todos { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}