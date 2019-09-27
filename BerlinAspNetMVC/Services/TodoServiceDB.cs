using BerlinAspNetMVC.Models;
using BerlinAspNetMVC.Models.DBModel;
using TodoDB = BerlinAspNetMVC.Models.DBModel.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BerlinAspNetMVC.Services
{
    public class TodoServiceDB: ITodoService
    {
        private readonly TodoContext _todoContext;
        public TodoServiceDB(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        List<Models.Todo> todos = new List<Models.Todo>()
        {
            new Models.Todo
            {
                Id = Guid.NewGuid(),
                Name = "Ein Todo",
                Description = "Beschreibung",
                IsDone = false
            },
            new Models.Todo
            {
                Id = Guid.NewGuid(),
                Name = "Ein anderes Todo",
                Description = "Beschreibung",
                IsDone = false
            },
        };
        public IEnumerable<Models.Todo> GetTodos()
        {
            var todosDB = _todoContext.Todos.ToList();
            var todos = new List<Models.Todo>();
            foreach (var todoDB in todosDB)
            {
                var todo = new Models.Todo()
                {
                    Id = todoDB.Id,
                    Name = todoDB.Name,
                    Description = todoDB.Description,
                    IsDone = todoDB.IsDone
                };
                todos.Add(todo);
            }
            return todos;
        }
        public Models.Todo GetTodo(Guid id)
        {
            var todo = _todoContext.Todos.Find(id);
            return MapTodoToBL(todo);
        }
        private Models.Todo MapTodoToBL(TodoDB todoDB)
        {
            var todo = new Models.Todo()
            {
                Id = todoDB.Id,
                Name = todoDB.Name,
                Description = todoDB.Description,
                IsDone = todoDB.IsDone
            };
            return todo;
        }

        private TodoDB MapTodoToDB(Models.Todo todo)
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
        public Models.Todo AddTodo(Models.Todo todo)
        {
            try
            {

                var todoDB = MapTodoToDB(todo);
                todoDB.Id = Guid.NewGuid();
                todoDB.CreatedAt = DateTime.Now;

                todoDB = _todoContext.Add(todoDB).Entity;
                _todoContext.SaveChanges();

                return GetTodo(todoDB.Id);
            } catch (DbUpdateException)
            {
                throw new Exception("Can't create Todo");
            }
        }
        public Models.Todo UpdateTodo(Models.Todo todo)
        {
            if(todo.Id == Guid.Empty)
            {
                throw new Exception("No id given");
            }

            var todoDB = MapTodoToDB(todo);
            var entity = _todoContext.Todos.Attach(todoDB);
            entity.Property(x => x.Name).IsModified = true;
            entity.Property(x => x.Description).IsModified = true;
            entity.Property(x => x.IsDone).IsModified = true;

            _todoContext.SaveChanges();

            todoDB = _todoContext.Todos.Find(todo.Id);


            todos[todos.FindIndex(x => x.Id == todo.Id)] = todo;
            return todo;
        }

        public void DeleteTodo(Models.Todo todo)
        {
            todos.Remove(todos.Find(x => x.Id == todo.Id));
        }

        public IEnumerable<Models.Todo> SearchTodos(string query)
        {
            return todos.Where(x => 
                x.Name.ToUpper().Contains(query.ToUpper()) ||
                x.Description.ToUpper().Contains(query.ToUpper())
            ).ToList();
        }
    }
}
