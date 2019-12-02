using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogData.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}