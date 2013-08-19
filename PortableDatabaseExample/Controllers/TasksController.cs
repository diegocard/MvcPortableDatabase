using PortableDatabaseExample.Models;
using System.Web.Mvc;

namespace PortableDatabaseExample.Controllers
{   
	public class TasksController : Controller
	{
		private ITaskRepository taskRepository;

		// If you are using Dependency Injection, you can delete the following constructor
		public TasksController() : this(new TaskRepository(true))
		{
		}

		public TasksController(ITaskRepository taskRepository)
		{
			this.taskRepository = taskRepository;
		}

		//
		// GET: /Tasks/

		public ViewResult Index(bool useSqlCE = true)
		{
			ManageRepository(useSqlCE);
			return View(taskRepository.All);
		}

		private void ManageRepository(bool useSqlCE)
		{
            this.taskRepository = new TaskRepository(useSqlCE);
		}

		//
		// GET: /Tasks/Details/5

		public ViewResult Details(int id)
		{
			return View(taskRepository.Find(id));
		}

		//
		// GET: /Tasks/Create

		public ActionResult Create()
		{
			return View();
		} 

		//
		// POST: /Tasks/Create

		[HttpPost]
		public ActionResult Create(Task task)
		{
			if (ModelState.IsValid) {
				taskRepository.InsertOrUpdate(task);
				taskRepository.Save();
				return RedirectToAction("Index");
			} else {
				return View();
			}
		}
		
		//
		// GET: /Tasks/Edit/5
 
		public ActionResult Edit(int id)
		{
			 return View(taskRepository.Find(id));
		}

		//
		// POST: /Tasks/Edit/5

		[HttpPost]
		public ActionResult Edit(Task task)
		{
			if (ModelState.IsValid) {
				taskRepository.InsertOrUpdate(task);
				taskRepository.Save();
				return RedirectToAction("Index");
			} else {
				return View();
			}
		}

		//
		// GET: /Tasks/Delete/5
 
		public ActionResult Delete(int id)
		{
			return View(taskRepository.Find(id));
		}

		//
		// POST: /Tasks/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			taskRepository.Delete(id);
			taskRepository.Save();

			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				taskRepository.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}

