using Solution.Domain.Entities;
using Solution.Domain.Interfaces.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly SolutionContext _context;

        public Repository(SolutionContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            var entity = _context.Set<T>().FirstOrDefault(expression);
            return entity;
        }

        public T Get(Guid id)
        {
            var entity = _context.Set<T>().FirstOrDefault(f => f.Id == id);
            return entity;
        }

        public List<T> GetList()
        {
            var entites = _context.Set<T>().ToList();
            return entites;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            var entites = _context.Set<T>().Where(expression).ToList();
            return entites;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
