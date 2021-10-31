using Imagegram.Repository.Interfaces;
using Imagegram.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Services.Implementations
{
	public class ImageService : IImageService
	{
		private readonly IImageRepository _imageRepository;
		public ImageService(IImageRepository imageRepository)
		{
			_imageRepository = imageRepository;
		}


	}
}
