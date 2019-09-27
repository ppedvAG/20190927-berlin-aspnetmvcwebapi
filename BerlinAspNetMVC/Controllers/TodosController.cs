using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BerlinAspNetMVC.Models;
using BerlinAspNetMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BerlinAspNetMVC.Controllers
{
    public class TodosController : Controller
    {
        private readonly ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            var todos = _todoService.GetTodos();
            return View(todos);
        }

        [Route("[controller]/{id}")]
        public IActionResult Detail(Guid id)
        {
            var todo = _todoService.GetTodo(id);
            return View(todo);
        }

        public IActionResult Create()
        {
            var todo = new Todo();
            return View(todo);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            todo.IsDone = false;
            _todoService.AddTodo(todo);
            return View(todo);
        }

        public IActionResult Edit(Guid id)
        {
            var todo = _todoService.GetTodo(id);
            return View(todo);
        }
        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            _todoService.UpdateTodo(todo);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var todo = _todoService.GetTodo(id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Delete(Todo todo, string operation)
        {
            if(operation != "abort")
            {
                _todoService.DeleteTodo(todo);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "SearchRole")]
        public IActionResult Search(string query)
        {
            User.IsInRole("");
            var todos = _todoService.SearchTodos(query);
            if(!todos.Any())
            {
                return View("SearchNotFound");
            }
            return View(todos);
        }
    }
}