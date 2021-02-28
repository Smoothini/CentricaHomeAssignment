using System.Collections.Generic;

namespace DataLayer.Interface
{
    public interface IDAO<T>
    {
        void Create(T t);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T t);
        void Delete(int id);
    }
}
