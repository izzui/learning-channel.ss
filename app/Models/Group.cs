using System;

namespace app.Models
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int UserId { get; set; }
		public int CourseId { get; set; }
	}
}

