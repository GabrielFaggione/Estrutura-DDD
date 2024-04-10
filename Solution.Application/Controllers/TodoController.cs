using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Domain.Interfaces.Services;

namespace Solution.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var todos = _todoService.GetAll();
            return Ok(todos);
        }

    }
}
