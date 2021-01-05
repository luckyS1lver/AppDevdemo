using System;

namespace GCD0704.AppDev.Models
{
	public class Todo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }

		public Todo(int id, string name, string description, DateTime dueDate)
		{
			Id = id;
			Name = name;
			Description = description;
			DueDate = dueDate;
		}
	}
}