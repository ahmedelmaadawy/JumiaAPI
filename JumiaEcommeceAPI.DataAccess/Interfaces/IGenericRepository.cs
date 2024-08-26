using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumiaEcommeceAPI.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> getAll();
        T getById(int id);
        void add(T item);
        void update(T item);
        void delete(T item);
        void save();

    }
}
