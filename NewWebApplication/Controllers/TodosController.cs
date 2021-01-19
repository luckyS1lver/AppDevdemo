using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewWebApplication.Models;

namespace NewWebApplication.Controllers
{
    public class TodosController : Controller
    {
        // GET: Todos
        private ApplicationDbContext _context;
        public TodosController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searchString)
        {

            var todo = _context.Todos.ToList();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                todo = _context.Todos.Where(t => t.Name.Contains(searchString)).ToList();
            }
            return View(todo);
        }

        public ActionResult Details(int id)
        {
            var todo = _context.Todos.SingleOrDefault(t => t.Id == id);
            return View(todo);
        }

        public ActionResult Delete(int id)
        {
            var todoinDb = _context.Todos.SingleOrDefault(t => t.Id == id);
            if (todoinDb == null)
            {
                return HttpNotFound();
            }
            _context.Todos.Remove(todoinDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var todoCreate = new Todo();
            todoCreate.Name = todo.Name;
            todoCreate.Description = todo.Description;
            todoCreate.DueDate = todo.DueDate;

            _context.Todos.Add(todoCreate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var todoInDB = _context.Todos.SingleOrDefault(t => t.Id == id);
            return View(todoInDB);
        }
        [HttpPost]
        public ActionResult Edit(Todo todo)
        {
            if(!ModelState.IsValid)
            {
                return View(todo);  
            }
            var todoInDB = _context.Todos.SingleOrDefault(t => t.Id == todo.Id);

            todoInDB.Name = todo.Name;
            todoInDB.Description = todo.Description;
            todoInDB.DueDate = todo.DueDate;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}