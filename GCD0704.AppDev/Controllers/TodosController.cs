using GCD0704.AppDev.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GCD0704.AppDev.Controllers
{
	public class TodosController : Controller
	{
		private ApplicationDbContext _context;
		public TodosController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Todos

		public ActionResult Index(string searchString)
		{
			var todos = _context.Todos.ToList();

			if (!String.IsNullOrWhiteSpace(searchString))
			{
				todos = _context.Todos.Where(t => t.Name.Contains(searchString)).ToList();
			}
			return View(todos);
		}

		public ActionResult Details(int id)
		{
			var todo = _context.Todos.SingleOrDefault(t => t.Id == id);
			return View(todo);
		}

		public ActionResult Delete(int id)
		{
			var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);
			if (todoInDb == null)
			{
				return HttpNotFound();
			}

			_context.Todos.Remove(todoInDb);
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
			var todoCreated = new Todo();
			todoCreated.Name = todo.Name;
			todoCreated.Description = todo.Description;
			todoCreated.DueDate = todo.DueDate;

			_context.Todos.Add(todoCreated);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);
			if (todoInDb == null) return HttpNotFound();

			return View(todoInDb);
		}

		[HttpPost]
		public ActionResult Edit(Todo todo)
		{
			var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == todo.Id);

			todoInDb.Name = todo.Name;
			todoInDb.Description = todo.Name;
			todoInDb.DueDate = todo.DueDate;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}