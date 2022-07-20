using NETCORE.MYSQL.Data.DBContext;
using NETCORE.MYSQL.Data.Repository;

namespace NETCORE.MYSQL.Data.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		protected readonly MySQLDBContext _context;

		public UnitOfWork(MySQLDBContext context)
		{
			_context = context;
			Products = new ProductRepository(_context);
		}

		public IProductRepository Products { get; private set; }

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
