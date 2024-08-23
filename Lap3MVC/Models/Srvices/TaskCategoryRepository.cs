using Microsoft.EntityFrameworkCore;

namespace Lap3MVC.Models.Srvices
{
	public class TaskCategoryRepository : IRepository<TaskCategory>
	{
		private readonly DBContext _context;

		public TaskCategoryRepository(DBContext context) 
		{
			_context = context;
		}
		public IEnumerable<TaskCategory> GetAll()
		{
			return _context.TaskCategories.ToList();
		}

		public TaskCategory? GetById(int id)
		{
			return _context.TaskCategories.FirstOrDefault(_c => _c.ID == id);
		}
		public TaskCategory Create(TaskCategory item)
		{
			 _context.TaskCategories.Add(item);
			_context.SaveChanges();
			return item;
		}
		public bool Update(TaskCategory item)
		{

			_context.TaskCategories.Update(item);
			_context.SaveChanges();
			return true;

		}

		public bool Delete(int id)
		{
			var cat=_context.TaskCategories.FirstOrDefault(c=> c.ID == id);
			_context.TaskCategories.Remove(cat);
			_context.SaveChanges();
			return true;
		}

		

		
	}
}
