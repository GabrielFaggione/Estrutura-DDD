using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Interfaces.Infrastructures
{
    public interface IRepository<T> where T : BaseEntity
    {

        T Add(T entity);
        bool Delete(T entity);
        T Update(T entity);
        T Get(Guid id);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> expression);
        T Find(Expression<Func<T, bool>> expression);

    }
}
