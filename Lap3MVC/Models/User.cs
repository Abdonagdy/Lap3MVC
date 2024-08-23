using System.ComponentModel.DataAnnotations.Schema;

namespace Lap3MVC.Models
{
	[Table("User")]
	public class User
	{
		

			public int Id { get; set; }
			public string Name { get; set; }
			public string Email { get; set; }

			public IEnumerable<Models.Task> Tasks { get; set; }
			public User(string name, string email)
			{
				
				Name = name;
				Email = email;
				Tasks = new List<Models.Task>();
			}
			public User():this(null!,null!) 
			{
			}

	}
}
