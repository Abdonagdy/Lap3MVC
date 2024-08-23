using System.Security.Cryptography;

namespace Lap3MVC.Models.Srvices
{
	public interface IRepository<TEntity>
	{
		IEnumerable<TEntity> GetAll();
		TEntity? GetById(int id);
		TEntity Create(TEntity item);
		bool Update(TEntity item);
		bool Delete(int id);
	}
}
