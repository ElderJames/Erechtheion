using DNIC.Erechtheion.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNIC.Erechtheion.EntityFrameworkCore
{
	public class RepositorySeedData : IRepositorySeedData
	{
		public void Init(string connectionString)
		{
			var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseSqlServer(connectionString)
				.Options;

			using (var db = new ApplicationDbContext(contextOptions, null))
			{
				if (!db.Topic.Any())
				{
					db.Topic.Add(new Domain.Entities.Topic
					{
						Name = "topic1"
					});
					db.Topic.Add(new Domain.Entities.Topic
					{
						Name = "topic2"
					});
					db.SaveChanges();
				}
			}
		}
	}
}
