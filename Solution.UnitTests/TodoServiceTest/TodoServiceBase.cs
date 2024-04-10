using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Solution.Domain.Entities.TodoAggregates;
using Solution.Domain.Interfaces.Infrastructures;
using Solution.Domain.Services;

namespace Solution.UnitTests.TodoServiceTest
{
    public class TodoServiceBase
    {

        public Mock<IRepository<Todo>> _todoRepository;
        public TodoService _todoService;

        public TodoServiceBase()
        {
            _todoRepository = new Mock<IRepository<Todo>>();
            _todoService = new TodoService(_todoRepository.Object);
        }

    }
}
