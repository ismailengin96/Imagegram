using Imagegram.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Data
{
	public class DataContext : DbContext, IDataContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{			
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
			modelBuilder.HasPostgresExtension("uuid-ossp")
				   .Entity<Comment>()
				   .Property(e => e.CommentId)
				   .HasDefaultValueSql("uuid_generate_v4()");
			modelBuilder.HasPostgresExtension("uuid-ossp")
				   .Entity<Image>()
				   .Property(e => e.ImageId)
				   .HasDefaultValueSql("uuid_generate_v4()");
			modelBuilder.HasPostgresExtension("uuid-ossp")
				   .Entity<Post>()
				   .Property(e => e.PostId)
				   .HasDefaultValueSql("uuid_generate_v4()");
			modelBuilder.HasPostgresExtension("uuid-ossp")
				   .Entity<User>()
				   .Property(e => e.UserId)
				   .HasDefaultValueSql("uuid_generate_v4()");

		}
		
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
