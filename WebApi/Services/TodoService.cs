using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBModels;
using TodoDB = WebApi.DBModels.Todo;
using WebApi.BLModels;
using Todo = WebApi.BLModels.Todo;
using WebApi.Services.Exceptions;

namespace WebApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _todoContext;
        public TodoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public Todo Map(TodoDB todoDB)
        {
            var todo = new Todo()
            {
                Id = todoDB.Id,
                Name = todoDB.Name,
                Description = todoDB.Description,
                IsDone = todoDB.IsDone
            };
            return todo;
        }

        public TodoDB Map(Todo todo)
        {
            var todoDB = new TodoDB()
            {
                Id = todo.Id,
                Name = todo.Name,
                Description = todo.Description,
                IsDone = todo.IsDone
            };
            return todoDB;
        }
        public Todo AddTodo(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            var todoDB = Map(todo);

            todoDB =_todoContext.Add(todoDB).Entity;
            _todoContext.SaveChanges();

            todo = Map(todoDB);

            return todo;
        }

        public void DeleteTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Todo GetTodo(Guid id)
        {
            var todoDB = _todoContext.Todos.Find(id);
            if(todoDB == null)
            {
                throw new ObjectNotFoundException($"Couldn't find Todo with id: {id}");
            }
            var todo = Map(todoDB);
            return todo;
        }

        public IEnumerable<Todo> GetTodos()
        {
            try
            {
                var todos = _todoContext.Todos.ToList().Select<TodoDB, Todo>(x => Map(x));
                return todos;
            }catch(Exception e)
            {
                throw new Exception("Serviceerror");
            }
        }

        public Todo UpdateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
