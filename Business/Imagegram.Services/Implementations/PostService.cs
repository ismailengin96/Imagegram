using Imagegram.DataTransferObjects;
using Imagegram.DataTransferObjects.Request;
using Imagegram.DataTransferObjects.Response;
using Imagegram.Models.Models;
using Imagegram.Repository.Interfaces;
using Imagegram.Services.Interfaces;
using Imagegram.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Services.Implementations
{
	public class PostService : IPostService
	{
		private readonly IPostRepository _postRepository;
		private readonly IImageRepository _imageRepository;
		private readonly IUserRepository _userRepository;
		private readonly List<string> allowedExtensions = new List<string>() { ".bmp", ".jpg", ".png" };
		private readonly string rootUploadPath = @"C:\imagegram\uploads\";
		public PostService(IPostRepository postRepository, IImageRepository imageRepository, IUserRepository userRepository)
		{
			_postRepository = postRepository;
			_imageRepository = imageRepository;
			_userRepository = userRepository;
		}
		public async Task<IdResponseBase> CreatePost(CreatePostRequest request)
		{
			if(request.UserId != null & request.UserId != Guid.Empty)
			{
				var user = _userRepository.Get(request.UserId);
				if (user == null)
					return new IdResponseBase() { Success = false, Message = "We couldn't find any user matching this UserId!" };

				var postId = Guid.NewGuid();
				var imageList = new List<Image>();
				string filePath = Path.Combine(rootUploadPath, postId.ToString());
				Directory.CreateDirectory(filePath);

				foreach (var imageFile in request.ImageList)
				{
					if (imageFile.Length > 0 && imageFile.Length / (1024 * 1024) <= 100 && allowedExtensions.Contains(Path.GetExtension(imageFile.FileName)))
					{
						Guid imageId = Guid.NewGuid();
						string extension = Path.GetExtension(imageFile.FileName);
						string fileName = string.Format("{0}{1}", imageId.ToString(), extension);
						string imagePath = Path.Combine(filePath, fileName);

						using (FileStream fileStream = new FileStream(imagePath, FileMode.Create))
						{
							await imageFile.CopyToAsync(fileStream);
						}
						imageList.Add(new Image()
						{
							CreatedDatetime = DateTime.Now,
							File = imageFile.FileName,
							MimeType = imageFile.ContentType,
							PostId = postId,
							ImageId = imageId
						});
					}
				}

				if (imageList.Count > 0)
				{
					Post post = new Post()
					{
						PostId = postId,
						Body = request.Body,
						CreatedDatetime = DateTime.Now,
						UserId = request.UserId
					};

					_postRepository.Save(post);
					_imageRepository.SaveList(imageList);

					return new IdResponseBase() { Id = postId, Success = true };
				}
				else
					return new IdResponseBase() { Success = false, Message = "You must upload atleast one valid image! Allowed image formats are .jpg, .bmp, .png and maximum image file size is 100MB" };
			}
			else
				return new IdResponseBase() { Success = false, Message = "You must an enter UserId! You can create a user on api/User/Create endpoint and use the Id you get as a response." };
		}

		public GetPostListResponse GetPostListWithComments(int? before, int? after, int size)
		{
			var postListWithComments = _postRepository.GetPostListWithComments(before, after, size);

			foreach (var postWithComments in postListWithComments)
			{
				IEnumerable<string> files = new List<string>();
				try
				{
					files = from file in Directory.EnumerateFiles(string.Format(@"{0}\{1}", rootUploadPath, postWithComments.Post.PostId.ToString())) select file;
				}
				catch (Exception)
				{

				}				
				IList<byte[]> imageList = new List<byte[]>();
				ImageEncoder encoder = new ImageEncoder();
				foreach (var file in files)
				{
					if(Path.GetExtension(file) != ".jpg")
						imageList.Add(encoder.ConvertImageToJpeg(file));
				}
				postWithComments.ImageList = imageList;
			}
			
			return new GetPostListResponse { PostList = postListWithComments, Success = true };
		}
	}
}
