using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TitanicAPI.Models;
using MySql.EntityFrameworkCore.Extensions;

namespace TitanicAPI
{
	public class PeopleDb : DbContext
	{
		public DbSet<Person> People { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

				if (string.IsNullOrWhiteSpace(connectionString))
					throw new ApplicationException("Missing connection string. DATABASE_URL environment variable not set");

				string dbms = Environment.GetEnvironmentVariable("DBMS");
				bool useMySQL = dbms != null && dbms.Equals("mysql", StringComparison.OrdinalIgnoreCase);

				if (useMySQL)
					optionsBuilder.UseMySQL(connectionString);
				else
					optionsBuilder.UseSqlServer(connectionString);
				
			}
		}
	}
}