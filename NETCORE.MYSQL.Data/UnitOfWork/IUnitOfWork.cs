using NETCORE.MYSQL.Data.Repository;

namespace NETCORE.MYSQL.Data.UnitOfWork
{
	public interface IUnitOfWork
	{
		IProductRepository Products { get; }

		int Complete();
		void Dispose();
	}
}