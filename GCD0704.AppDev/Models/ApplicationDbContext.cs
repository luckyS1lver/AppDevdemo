using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GCD0704.AppDev.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
				: base("Model1", throwIfV1Schema: false)
		{
		}
		public DbSet<Todo> Todos { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<TodoUser> TodoUsers { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}