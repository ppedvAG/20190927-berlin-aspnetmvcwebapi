using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.BLModels;
using WebApi.Services;
using WebApi.Services.Exceptions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodosController> _logger;
        public TodosController(ITodoService todoService, ILogger<TodosController> logger)
        {
            _todoService = todoService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Todo> Get()
        {
            return _todoService.GetTodos();
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> Get(Guid id)
        {
            try
            {
                var todo = _todoService.GetTodo(id);
                return todo;
            } catch(ObjectNotFoundException e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Todo> Post(Todo todo)
        {
            todo = _todoService.AddTodo(todo);
            return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        }
    }
}