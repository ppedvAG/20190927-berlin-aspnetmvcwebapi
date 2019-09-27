using BerlinAspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerlinAspNetMVC.Services
{
    public class TodoService: ITodoService
    {
        List<Todo> todos = new List<Todo>()
        {
            new Todo
            {
                Id = Guid.NewGuid(),
                Name = "Ein Todo",
                Description = "Beschreibung",
                IsDone = false
            },
            new Todo
            {
                Id = Guid.NewGuid(),
                Name = "Ein anderes Todo",
                Description = "Beschreibung",
                IsDone = false
            },
        };
        public IEnumerable<Todo> GetTodos()
        {
            return todos;
        }
        public Todo GetTodo(Guid id)
        {
            var todo = todos.Find(x => x.Id == id);
            return todo;
        }

        public Todo AddTodo(Todo todo)
        {
            todo.Id = Guid.NewGuid();

            todos.Add(todo);
            return todo;
        }
        public Todo UpdateTodo(Todo todo)
        {
            todos[todos.FindIndex(x => x.Id == todo.Id)] = todo;
            return todo;
        }

        public void DeleteTodo(Todo todo)
        {
            todos.Remove(todos.Find(x => x.Id == todo.Id));
        }

        public IEnumerable<Todo> SearchTodos(string query)
        {
            return todos.Where(x => 
                x.Name.ToUpper().Contains(query.ToUpper()) ||
                x.Description.ToUpper().Contains(query.ToUpper())
            ).ToList();
        }
    }
}
