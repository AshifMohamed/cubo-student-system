using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        bool CheckRecordExists(Expression<Func<T, bool>> expression);

    }
}
