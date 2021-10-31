using Imagegram.DataTransferObjects;
using Imagegram.DataTransferObjects.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Services.Interfaces
{
	public interface ICommentService
	{
		IdResponseBase CreateComment(CreateCommentRequest request);
		ResponseBase Delete(DeletePostRequest request);
	}
}
