using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;
using System;
using ServiceStack.OrmLite;
using app.Models;
using System.Data;

class Program {

	public class AppHost : AppHostHttpListenerBase {
		public AppHost() : base("HttpListener", typeof(Program).Assembly) { }

		public override void Configure(Funq.Container container) {
			container.Register<IDbConnectionFactory> (new OrmLiteConnectionFactory(":memory:", false, SqliteDialect.Provider) );
		}
	}

	static void Main(string[] args)
	{
		var listeningOn = args.Length == 0 ? "http://*:1337/" : args[0];
		var appHost = new AppHost();
		appHost.Init();

		IDbConnectionFactory dbf = appHost.TryResolve<IDbConnectionFactory> ();
		IDbConnection db = dbf.OpenDbConnection ();
		db.DropAndCreateTable<Course>();

		for (int i = 1; i <= 100; i++) {
			db.Insert<Course> (new Course { Title = "Teste " + i });
		}

		appHost.Start(listeningOn);

		Console.WriteLine("AppHost Created at {0}, listening on {1}", DateTime.Now, listeningOn);
		Console.ReadKey();
	}
}