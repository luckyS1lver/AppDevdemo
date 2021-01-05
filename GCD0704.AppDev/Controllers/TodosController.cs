using GCD0704.AppDev.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GCD0704.AppDev.Controllers
{
	public class TodosController : Controller
	{
		// GET: Todos

		public ActionResult Index()
		{
			List<Todo> Todos = new List<Todo>();
			Todo todo = new Todo(1, "Kill John", "Kill !!!", new System.DateTime(2008, 5, 1, 8, 30, 52));

			return View(todo);
		}
	}
}