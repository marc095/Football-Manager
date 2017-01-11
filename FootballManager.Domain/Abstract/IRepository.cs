using System.Linq;

namespace FootballManager.Domain.Abstract
{
    public interface IRepository<T>
    {
        IQueryable<T> Entities { get; }
        void Save(T entity);
        void Delete(int id);
    }
}
