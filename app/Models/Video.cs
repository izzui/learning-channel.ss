using System;

namespace app.Models
{
	public class Video
	{
		public enum EnumProgress { 
			notStarted,
			inProgress,
			completed
		}

		public int Id { get; set; }
		public string Thumb { get; set; }
		public string Url { get; set; }
		public int LessonId { get; set; }
		public EnumProgress Progress { get; set; }
	}
}

