using Imagegram.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Data
{
	public interface IDataContext
	{
		DbSet<Comment> Comments { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<User> Users { get; set; }
		int SaveChanges();
	}
}
