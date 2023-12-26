using AutoMapper;
using SocialNetwork.Core.Application.Interface.Repositories;
using SocialNetwork.Core.Application.Interface.Services;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class PostService:GenericService<PostSaveViewModel, PostViewModel, Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, IMapper mapper):base(postRepository, mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PostViewModel>> GetAllInclude()
        {
            var posts = await _postRepository.GetAllInclude(new List<string> { "User" });
            return posts.Select(posts => new PostViewModel
            {
                Id = posts.Id,
                Content = posts.Content,
                UserId = posts.UserId,
                NameUser = posts.User.Name,
                LastNameUser = posts.User.LastName,
                ImgUrlUser = posts.User.Photo,
                CreatedDate = posts.CreatedDate,
                CommentsCount = posts.comments.Count(),
            });

        }
    }
}
