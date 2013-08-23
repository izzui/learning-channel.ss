using System;
using System.Collections.Generic;

namespace app.Models
{
		public class Lesson
		{
			public int Id { get; set; }
			public string Title { get; set; }
			public ICollection<Video> Videos { get; set; }
			public int CourseId { get; set; }
		}
}

