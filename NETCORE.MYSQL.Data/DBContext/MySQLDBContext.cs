using Microsoft.EntityFrameworkCore;
using NETCORE.MYSQL.Data.Models;
using System.Reflection;

namespace NETCORE.MYSQL.Data.DBContext
{
	public class MySQLDBContext : DbContext
	{
		public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options)
		{
		}

		public DbSet<Product> products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
