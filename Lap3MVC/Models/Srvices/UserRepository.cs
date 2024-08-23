namespace Lap3MVC.Models.Srvices
{
	public class UserRepository:IRepository<User>
	{
		private readonly DBContext _context;

		public UserRepository(DBContext context)
		{
			_context = context;
		}
		public IEnumerable<User> GetAll()
		{
			return _context.Users.ToList();
		}
		public User? GetById(int id)
		{
			return _context.Users.FirstOrDefault(_c => _c.Id == id);
		}
		public User Create(User item)
		{
			_context.Users.Add(item);
			_context.SaveChanges();
			return item;
		}

		public bool Delete(int id)
		{
			var cat = _context.Users.FirstOrDefault(c => c.Id == id);
			_context.Users.Remove(cat);
			_context.SaveChanges();
			return true;
		}
		public bool Update(User item)
		{
			_context.Users.Update(item);
			_context.SaveChanges();
			return true;
		}
	}
}
