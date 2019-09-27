using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BLModels;

namespace WebApi.Services
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetTodos();
        Todo GetTodo(Guid id);
        Todo AddTodo(Todo todo);
        Todo UpdateTodo(Todo todo);
        void DeleteTodo(Todo todo);
    }
}
