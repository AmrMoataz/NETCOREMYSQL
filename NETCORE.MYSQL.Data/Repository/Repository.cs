using NETCORE.MYSQL.Data.DBContext;
using NETCORE.MYSQL.Data.Models;
using System.Linq.Expressions;

namespace NETCORE.MYSQL.Data.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : AuditableEntity
	{
		protected readonly MySQLDBContext Context;

		public Repository(MySQLDBContext context)
		{
			Context = context;
		}

		public void Add(TEntity entity)
		{
			PopulateAutiableProperties(entity);
			Context.Set<TEntity>().Add(entity);
		}

		private static void PopulateAutiableProperties(TEntity entity)
		{
			entity.CreatedBy = string.IsNullOrWhiteSpace(entity.CreatedBy) ? "Admin" : entity.CreatedBy;
			entity.Created = DateTime.Now;
			entity.EntityId = Guid.NewGuid().ToString();
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			foreach (var entity in entities)
			{
				PopulateAutiableProperties(entity);
			}
			Context.Set<TEntity>().AddRange(entities);
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Set<TEntity>().Where(predicate);
		}

		public TEntity Get(int id)
		{
			return Context.Set<TEntity>().Find(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return Context.Set<TEntity>().ToList();
		}

		public void Remove(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().RemoveRange(entities);
		}
	}
}
