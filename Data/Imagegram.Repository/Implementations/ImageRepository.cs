using Imagegram.Data;
using Imagegram.Models.Models;
using Imagegram.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Repository.Implementations
{
	public class ImageRepository : IImageRepository
	{
		private readonly IDataContext _context;

		public ImageRepository(IDataContext context)
		{
			_context = context;
		}
		public int SaveList(IList<Image> images)
		{
			_context.Images.AddRange(images);
			return _context.SaveChanges();
		}
	}
}
