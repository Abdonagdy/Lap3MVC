using Lap3MVC.Models;
using Lap3MVC.Models.Srvices;
using Microsoft.AspNetCore.Mvc;

namespace Lap3MVC.Controllers
{
	public class UserController : Controller
	{
		private readonly IRepository<User> _userRepository;

		public UserController(IRepository<User> userRepository)
		{
			_userRepository=userRepository;
		}
		//public IActionResult Index(int id)
		//{
		//	var im = _imageRepository.GetById(id);
		//	if(im!=null)
		//	ViewData["img"] =im;
		//	return View();
		//}
		public IActionResult Index()
		{
			//HttpContext.Session.SetString("Adel", "Developer");
			//var name = HttpContext.Session.GetString("Adel");

			return View(_userRepository.GetAll());
		}
		public IActionResult Details(int id)
		{
			if (!ModelState.IsValid)
				return View(id);
			try
			{
				return View(_userRepository.GetById(id));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}

		}
		public IActionResult New()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult New(User user)
		{
			if (!ModelState.IsValid)
				return View(user);
			try
			{
				_userRepository.Create(user);
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(user);
			}

		}
		public IActionResult Edite(int id)
		{
			if (!ModelState.IsValid)
				return View(id);
			try
			{
				return View(_userRepository.GetById(id));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(id);
			}
		}
		[HttpPost]
		public IActionResult Edite(User user)
		{

			if (!ModelState.IsValid)
				return View(user);
			try
			{
				_userRepository.Update(user);
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				ModelState.AddModelError(" ", ex.Message);
				return View(user);
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
				_userRepository.Delete(id);
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
