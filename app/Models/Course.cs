using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace app.Models
{
	public class Course
	{
		[AutoIncrement]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Thumb { get; set; }
		public double Price { get; set; }
		public double Rating { get; set; }
		public long Views { get; set; }
		public long Subscriptions { get; set; }
		public DateTime PublishDate { get; set; }
		public string Language { get; set; }
		public ICollection<Author> Authors { get; set; }
		public ICollection<Group> Groups { get; set; }
		public ICollection<Lesson> Lessons { get; set; }
	}
}

