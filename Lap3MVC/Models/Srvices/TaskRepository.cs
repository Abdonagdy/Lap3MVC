namespace Lap3MVC.Models.Srvices
{
	public class TaskRepository:IRepository<Lap3MVC.Models.Task>
	{
		private readonly DBContext _context;

		public TaskRepository(DBContext context)
		{
			_context = context;
		}
		public IEnumerable<Lap3MVC.Models.Task> GetAll()
		{
			return _context.Tasks.ToList();
		}

		public Lap3MVC.Models.Task? GetById(int id)
		{
			return _context.Tasks.FirstOrDefault(_c => _c.Id == id);
		}
		public Lap3MVC.Models.Task Create(Lap3MVC.Models.Task item)
		{
			_context.Tasks.Add(item);
			_context.SaveChanges();
			return item;
		}
		public bool Update(Lap3MVC.Models.Task item)
		{

			_context.Tasks.Update(item);
			_context.SaveChanges();
			return true;

		}

		public bool Delete(int id)
		{
			var cat = _context.Tasks.FirstOrDefault(c => c.Id == id);
			_context.Tasks.Remove(cat);
			_context.SaveChanges();
			return true;
		}
	}
}
