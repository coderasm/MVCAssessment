using System.Collections.Generic;

namespace Assessment.Domain.Repositories
{
    public interface IRepository<T>
    {
        T Select(int id);
        List<T> Select();
        void Insert(T poco);
        void Update(T poco);
        bool Delete(int id);
    }
}
