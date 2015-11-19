using System.Collections.Generic;

namespace Assessment.Domain.Repositories
{
    public interface IRepository<T>
    {
        T Select(int id);
        List<T> Select();
        bool Insert(T poco);
        bool Update(T poco);
        bool Delete(int id);
    }
}
