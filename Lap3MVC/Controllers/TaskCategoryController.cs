using Lap3MVC.Models;
using Lap3MVC.Models.Srvices;
using Microsoft.AspNetCore.Mvc;

namespace Lap3MVC.Controllers
{
	public class TaskCategoryController : Controller
	{
		private readonly IRepository<TaskCategory> _taskcategoeryRepository;

		public TaskCategoryController(IRepository<TaskCategory> taskcategoeryRepository) 
		{
			_taskcategoeryRepository = taskcategoeryRepository;
		}
		public IActionResult Index()
		{
			
			return View(_taskcategoeryRepository.GetAll());
		}
		public IActionResult New()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult New(TaskCategory taskCategory)
		{
			if (!ModelState.IsValid)
				return View(taskCategory);
			try
			{
				_taskcategoeryRepository.Create(taskCategory);
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(taskCategory);
			}

		}
	}
}
