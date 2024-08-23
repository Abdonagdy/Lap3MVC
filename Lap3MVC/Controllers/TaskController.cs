using Lap3MVC.Models;
using Lap3MVC.Models.Srvices;
using Microsoft.AspNetCore.Mvc;



namespace Lap3MVC.Controllers
{
	public class TaskController : Controller
	{
		private readonly IRepository<Models.Task> _taskRepository;
		private readonly IRepository<TaskCategory> _taskCategoryRepository;
		private readonly IRepository<User> _userRepository;
		//DBContext _dBContext;

		public TaskController(IRepository<Models.Task> taskRepository,IRepository<TaskCategory> taskCategoryRepository,IRepository<User> userRepository)
		{
			_taskRepository = taskRepository;
			_taskCategoryRepository = taskCategoryRepository;
			_userRepository = userRepository;
			//_dBContext = dBContext;
		}
		public IActionResult Index(string? TaskName, Models.TaskStatus? statusTaskFilter)
		{
			var tasks = _taskRepository.GetAll();

			if (!String.IsNullOrEmpty(TaskName))
			{
				tasks = tasks.Where(task => task.Name.Contains(TaskName));
			}

			if (statusTaskFilter.HasValue)
			{
				tasks = tasks.Where(task => task.Status == statusTaskFilter.Value);
			}

			

			return View(tasks.ToList());
		}
		//public IActionResult Index()
		//{
		//	//HttpContext.Session.SetString("Adel", "Developer");
		//	//var name = HttpContext.Session.GetString("Adel");
		//	//var tasks = _tastRepository.GetAll().ToList();




		//	return View(_taskRepository.GetAll()) ;
		//}
		public IActionResult Details(int id)
		{
		
			try
			{
				return View(_taskRepository.GetById(id));
			}catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}

		}
		public IActionResult New()
		{
			ViewBag.Categories = _taskCategoryRepository.GetAll();
			ViewBag.Users = _userRepository.GetAll();

			return View();
		}
		[HttpPost]
		
		public IActionResult New(Models.Task task )
		{
		

			try
			{
				_taskRepository.Create(task);
				return RedirectToAction("Index");

			}catch(Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(task);
			}
			
		}
		public IActionResult Edite(int id) 
		{
			ViewBag.Categories = _taskCategoryRepository.GetAll();
			ViewBag.Users = _userRepository.GetAll();

			try
			{
				return View(_taskRepository.GetById(id));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}
		}
		[HttpPost]
		public IActionResult Edite(Models.Task task)
		{
		
			try
			{
				_taskRepository.Update(task);
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(task);
			}
		}
		public IActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
			{
				return View(id);
			}
			try
			{
				_taskRepository.Delete(id);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}

		}
	}
}
