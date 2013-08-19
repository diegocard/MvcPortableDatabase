using PortableDatabaseExample.Models;
using PortableDatabaseExample.Repository;
using System.Web.Mvc;

namespace PortableDatabaseExample.Controllers
{   
	public class TasksController : Controller
	{
    	//
		// GET: /Tasks/

		public ViewResult Index(bool? useSqlCE)
		{
            ITaskRepository taskRepository;
            if (useSqlCE.HasValue)
            {
                taskRepository = TaskRepositoryFactory.Instance.GetTaskRepository(useSqlCE.Value);
            }
            else
            {
                taskRepository = TaskRepositoryFactory.Instance.GetTaskRepository();
            }
			return View(taskRepository.All);
		}

		//
		// GET: /Tasks/Details/5

		public ViewResult Details(int id)
		{
            ITaskRepository taskRepository = TaskRepositoryFactory.Instance.GetTaskRepository();
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
            ITaskRepository taskRepository = TaskRepositoryFactory.Instance.GetTaskRepository();
			if (ModelState.IsValid) {
				taskRepository.InsertOrUpdate(task);
				taskRepository.Save();
                return RedirectToAction("Index", "Tasks");
			} else {
				return View();
			}
		}
		
		//
		// GET: /Tasks/Edit/5
 
		public ActionResult Edit(int id)
		{
            ITaskRepository taskRepository = TaskRepositoryFactory.Instance.GetTaskRepository();
			 return View(taskRepository.Find(id));
		}

		//
		// POST: /Tasks/Edit/5

		[HttpPost]
		public ActionResult Edit(Task task)
		{
            ITaskRepository taskRepository = TaskRepositoryFactory.Instance.GetTaskRepository();
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
            ITaskRepository taskRepository = TaskRepositoryFactory.Instance.GetTaskRepository();
			return View(taskRepository.Find(id));
		}

		//
		// POST: /Tasks/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
            ITaskRepository taskRepository = TaskRepositoryFactory.Instance.GetTaskRepository();
			taskRepository.Delete(id);
			taskRepository.Save();

			return RedirectToAction("Index");
		}
	}
}

