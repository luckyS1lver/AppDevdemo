using GCD0704.AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GCD0704.AppDev.Controllers
{
	public class TodosController : Controller
	{
		// GET: Todos
		List<Todo> todos = new List<Todo>()
			{
				new Todo(1, "Kill John", "Kill Them All !!!", new DateTime(2008, 5, 1, 8, 30, 52)),
				new Todo(2, "Kill Bill", "Kill ....", new DateTime(2008, 5, 1, 8, 30, 52)),
				new Todo(3, "Kill Wick", "Kill ....", new DateTime(2008, 5, 1, 8, 30, 52))
			};

		public ActionResult Index()
		{
			return View(todos);
		}

		public ActionResult Details(int id)
		{
			var todo = todos.SingleOrDefault(t => t.Id == id);
			return View(todo);
		}
	}
}