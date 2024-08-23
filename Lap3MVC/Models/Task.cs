using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lap3MVC.Models
{
	[Table("Task")]
	public class Task
	{
		
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime AssignDate { get; set; }
		public TaskStatus Status { get; set; }
		[Display(Name = "User")]
		public int UserId { get; set; }
		[Display(Name="TaskCategory")]
		public int CategoryId { get; set; }
		[ForeignKey(nameof(CategoryId))]
		public TaskCategory Category { get; set; }
		[ForeignKey(nameof(UserId))]
		public User Owner { get; set; }
	
		public Task(string name, string description, DateTime assignDate, TaskStatus status, int userid,int catid )
		{

			Name = name;
			Description = description;
			AssignDate = assignDate;
			Status = status;
			UserId= userid;
			CategoryId= catid;
			
		}
		public Task() : this(null!, null!, DateTime.Now,0, 0, 0)
		{
		}
	}
	public enum TaskStatus
	{
		Open = 0,
		InProgress = 1,
		Done = 2
	}
	

}

