using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryContracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(int id);
        IEnumerable<T> GetAll();
       // IEnumerable<T> Filter(Func<T, bool> predicate);
    }
}
