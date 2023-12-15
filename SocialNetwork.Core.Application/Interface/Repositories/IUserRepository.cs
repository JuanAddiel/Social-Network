using SocialNetwork.Core.Application.ViewModels.User;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interface.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Login(LoginViewModel loginViewModel);
    }
}
