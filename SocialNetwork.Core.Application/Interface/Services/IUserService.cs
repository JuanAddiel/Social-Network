using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Application.ViewModels.User;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interface.Services
{
    public interface IUserService:IGenericService<UserSaveViewModel, UserViewModel, User>
    {
        Task<IEnumerable<UserViewModel>> GetAllInclude();
    }
}
