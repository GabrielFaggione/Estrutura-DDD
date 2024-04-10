using Solution.Domain.Entities.TodoAggregates;
using Solution.Domain.Extensions;
using Solution.Domain.Interfaces.Infrastructures;
using Solution.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Services
{
    public class TodoService : ITodoService
    {

        private readonly IRepository<Todo> _todoRepository;

        public TodoService(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public Todo Add(TodoCreationRequest todoCreationRequest)
        {

            var todo = _todoRepository.Find(f => f.Description == todoCreationRequest.Description);
            if (todo != null)
                throw new DuplicateException();

            todo = new Todo(todoCreationRequest.Description);
            _todoRepository.Add(todo);

            return todo;
        }

        public bool Delete(Guid todoId)
        {
            var todo = _todoRepository.Get(todoId);
            if (todo == null)
                throw new NotFoundException<Todo>(todoId);

            var isDeleted = _todoRepository.Delete(todo);
            return isDeleted;
        }

        public Todo Get(Guid todoId)
        {
            var todo = _todoRepository.Get(todoId);
            if (todo == null)
                throw new NotFoundException<Todo>(todoId);
            return todo;
        }

        public List<Todo> GetAll()
        {
            var todoList = _todoRepository.GetList();
            return todoList;
        }

        public List<Todo> GetList(Expression<Func<Todo, bool>> expression)
        {
            var todoList = _todoRepository.GetList(expression);
            return todoList;
        }

        public Todo Update(Guid id, TodoUpdateRequest todoUpdateRequest)
        {
            var todo = _todoRepository.Get(id);
            if (todo == null)
                throw new NotFoundException<Todo>(id);

            todo.IsCompleted = todoUpdateRequest.IsCompleted;
            _todoRepository.Update(todo);

            return todo;
        }
    }
}
