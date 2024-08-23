

using System.ComponentModel.DataAnnotations.Schema;

namespace Lap3MVC.Models
{
	[Table("TaskCategory")]
	public class TaskCategory
	{
		

			public int ID { get; set; }
			public string Category { get; set; }

			public List<Models.Task> Tasks { get; set; }
			public TaskCategory(string category)
			{
			
				Category = category;
				Tasks =new  List<Models.Task>();
			}
			public TaskCategory():this(null!)
			{

			}

	}
}
