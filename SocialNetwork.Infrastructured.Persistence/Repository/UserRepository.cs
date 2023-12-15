using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interface.Repositories;
using SocialNetwork.Core.Application.ViewModels.User;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Infrastructured.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructured.Persistence.Repository
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }
        public override Task<User> Add(User entity)
        {
            entity.Password = PasswordEncryption.Encrypt(entity.Password);
            return base.Add(entity);
        }
        public async Task<User> Login(LoginViewModel loginViewModel)
        {
            loginViewModel.Password = PasswordEncryption.Encrypt(loginViewModel.Password);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password );
            return user;
        }
    }
}
