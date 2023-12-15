using AutoMapper;
using SocialNetwork.Core.Application.Interface.Repositories;
using SocialNetwork.Core.Application.Interface.Services;
using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class CommentService:GenericService<CommentSaveViewModel, CommentViewModel, Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper):base(commentRepository, mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentViewModel>> GetAllInclude()
        {
            var comments = await _commentRepository.GetAllInclude(new List<string> { "User", "Post"});
            return comments.Select(comments => new CommentViewModel
            {
                Id = comments.Id,
                Content = comments.Content,
                UserId = comments.UserId,
                PostId = comments.PostId,
                NameUser = comments.User.Name,
                LastNameUser = comments.User.LastName,
                ImgUrlUser = comments.User.Photo
            });
        }
    }
}
