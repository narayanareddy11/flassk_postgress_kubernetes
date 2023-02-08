using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace TitanicAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			using ILoggerFactory loggerFactory =
				LoggerFactory.Create(builder =>
					builder.AddSimpleConsole(options =>
					{
						options.IncludeScopes = true;
						options.SingleLine = true;
						options.TimestampFormat = "hh:mm:ss ";
					}));

			ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}