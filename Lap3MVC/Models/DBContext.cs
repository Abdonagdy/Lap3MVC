
using Microsoft.EntityFrameworkCore;

namespace Lap3MVC.Models
{
	public class DBContext:DbContext
	{
		public DBContext()
		{

		}
		public DBContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<User> Users { get; set; }
		public DbSet<TaskCategory> TaskCategories { get; set; }

		public DbSet<Task> Tasks { get; set; }


	}
}
