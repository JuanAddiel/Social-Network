using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interface.Services
{
    public interface IFriendService:IGenericService<FriendSaveViewModel, FriendViewModel, Friend>
    {
        Task<IEnumerable<FriendViewModel>> GetAllInclude(int skip, int take);
    }
}
