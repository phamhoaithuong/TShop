using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Base
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entity);
        T GetById(int? id);
        IQueryable<T> All(int skipRow = 0, int takeRow = 10);
    }
}
