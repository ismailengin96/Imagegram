using Imagegram.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Repository.Interfaces
{
	public interface IImageRepository
	{
		int SaveList(IList<Image> image);
	}
}
