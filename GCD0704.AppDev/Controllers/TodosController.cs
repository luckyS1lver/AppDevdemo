using GCD0704.AppDev.Models;
using GCD0704.AppDev.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GCD0704.AppDev.Controllers
{
	[Authorize]
	[Authorize(Roles = "user")]
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
			var currentUserId = User.Identity.GetUserId();
			var todos = _context.TodoUsers
				.Where(t => t.UserId == currentUserId)
				.Select(t => t.Todo)
				.Include(t => t.Category)
				.ToList();

			if (!String.IsNullOrWhiteSpace(searchString))
			{
				todos = _context.TodoUsers
				.Where(t => t.UserId == currentUserId)
				.Select(t => t.Todo)
				.Include(t => t.Category)
				.Where(t => t.Name.Contains(searchString))
				.ToList();
			}
			return View(todos);
		}

		public ActionResult Details(int id)
		{
			var currentUserId = User.Identity.GetUserId();

			var todo = _context.TodoUsers
				.Where(t => t.UserId == currentUserId && t.TodoId == id)
				.Select(t => t.Todo)
				.Include(t => t.Category)
				.FirstOrDefault();

			if (todo == null) return HttpNotFound();

			return View(todo);
		}

		public ActionResult Delete(int id)
		{
			var currentUserId = User.Identity.GetUserId();

			var todoInDb = _context.TodoUsers.SingleOrDefault(t => t.TodoId == id && t.UserId == currentUserId);

			if (todoInDb == null)
			{
				return HttpNotFound();
			}

			_context.TodoUsers.Remove(todoInDb);

			var todo = _context.Todos.SingleOrDefault(t => t.Id == id);

			_context.Todos.Remove(todo);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Create()
		{
			var viewModel = new TodoCategoriesViewModel()
			{
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);

		}

		[HttpPost]
		public ActionResult Create(Todo todo)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var todoCreated = new Todo();
			todoCreated.Name = todo.Name;
			todoCreated.Description = todo.Description;
			todoCreated.DueDate = todo.DueDate;
			todoCreated.CategoryId = todo.CategoryId;

			_context.Todos.Add(todoCreated);

			var currentUserId = User.Identity.GetUserId();
			var todoUser = new TodoUser()
            {
				TodoId = todoCreated.Id,
				UserId = currentUserId
            };

			_context.TodoUsers.Add(todoUser);

			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var currentUserId = User.Identity.GetUserId();

			var todoUserInDb = _context.TodoUsers
				.SingleOrDefault(t => t.UserId == currentUserId && t.TodoId == id);

			if (todoUserInDb == null) return HttpNotFound();

			var viewModel = new TodoCategoriesViewModel()
			{
				Todo = _context.Todos.SingleOrDefault(t => t.Id == id),
				Categories = _context.Categories.ToList()
			}; 

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(Todo todo)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new TodoCategoriesViewModel()
				{
					Todo = todo,
					Categories = _context.Categories.ToList()
				};
				return View(viewModel);
			}

			var currentUserId = User.Identity.GetUserId();

			var todoUserInDb = _context.Todos.SingleOrDefault(t => t.Id == todo.Id);

			if (todoUserInDb == null) return HttpNotFound();

			var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == todo.Id);

			todoInDb.Name = todo.Name;
			todoInDb.Description = todo.Description;
			todoInDb.DueDate = todo.DueDate;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}