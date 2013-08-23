using System;
using System.Collections.Generic;
using app.Models;
using ServiceStack.ServiceHost;
using ServiceStack.OrmLite;
using System.Data;
using ServiceStack.ServiceInterface;

namespace app.Services
{
	public class CourseService : Service
	{
		[Route("/courses", "GET")]
		public class CoursesListReq : IReturn<List<Course>> {
			public string language { get; set; }
			public string limit { get; set; }
			public string offset { get; set; }
			public string sort { get; set; }
		}

		[Route("/courses/{Id}", "GET")]
		public class CourseGetReq : IReturn<Course> { 
			public int Id { get; set; } 
		}

		[Route("/courses/{Id}", "DELETE")]
		public class CourseDeleteReq : IReturn<bool> { 
			public int Id { get; set; } 
		}

		[Route("/courses", "POST")]
		public class CoursePostReq : IReturn<Int64> {
			public Course Course { get; set; }
		}

		[Route("/courses/{Id}", "PUT")]
		public class CoursePutReq : IReturn<Course> {
			public int Id { get; set; }
			public Course Course { get; set; }
		}

		public List<Course> Get(CoursesListReq request) {
			var exp = ReadExtensions.CreateExpression<Course> ();

			if (!String.IsNullOrEmpty (request.language))
				exp.Where (x => x.Language == request.language);

			if (!String.IsNullOrEmpty (request.sort))
				exp.OrderBy("ORDER BY " + request.sort);

			exp.Limit(String.IsNullOrEmpty (request.offset) ? 0 : Int32.Parse(request.offset),
				String.IsNullOrEmpty(request.limit) ? 20 : Int32.Parse(request.limit));

			var list = Db.Select<Course> (exp);
			Console.WriteLine (Db.GetLastSql ());
			return list;
		}

		public Course Get(CourseGetReq request) {
			return Db.GetById<Course> (request.Id);
		}

		public bool Delete(CourseDeleteReq request) {
			Db.DeleteById<Course> (request.Id);
			return true;
		}

		public Int64 Post(CoursePostReq request) {
			Db.Save<Course> (request.Course);
			return Db.GetLastInsertId ();
		}

		public Course Put(CoursePutReq request) {
			request.Course.Id = request.Id;
			Db.Update<Course> (request.Course, x => x.Id == request.Id);
			return request.Course;
		}
	}
}

