using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interface.Services
{
    public interface ICommentService:IGenericService<CommentSaveViewModel, CommentViewModel, Comment>
    {
        Task<IEnumerable<CommentViewModel>> GetAllInclude(int postId, int skip, int take);
    }
}
