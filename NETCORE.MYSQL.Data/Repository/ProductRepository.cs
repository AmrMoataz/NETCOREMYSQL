using NETCORE.MYSQL.Data.DBContext;
using NETCORE.MYSQL.Data.Models;
using System.Linq.Expressions;

namespace NETCORE.MYSQL.Data.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(MySQLDBContext context) : base(context)
		{
		}
	}
}
