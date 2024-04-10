using Solution.Domain.Entities.TodoAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Interfaces.Services
{
    public interface ITodoService
    {

        Todo Add(TodoCreationRequest todoCreationRequest);
        Todo Update(Guid id, TodoUpdateRequest todoUpdateRequest);
        bool Delete(Guid todoId);
        Todo Get(Guid todoId);
        List<Todo> GetAll();
        List<Todo> GetList(Expression<Func<Todo, bool>> expression);

    }
}
