using Microsoft.EntityFrameworkCore;

namespace Book_Store_Api.Models
{
	public class MyDbContext:DbContext
	{
		public MyDbContext(DbContextOptions options):base(options)
		{

		}
		public DbSet<Registration> Registrations { get; set; }
		public DbSet<Login> Logins { get; set; }
		public DbSet<BookCategory> BookCategories { get; set; }
		public DbSet<Books> Bookss { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Payment> Payments { get; set; }
	}
}
