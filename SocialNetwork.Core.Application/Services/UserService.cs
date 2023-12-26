using AutoMapper;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interface.Repositories;
using SocialNetwork.Core.Application.Interface.Services;
using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Application.ViewModels.User;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class UserService:GenericService<UserSaveViewModel, UserViewModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper):base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Login(LoginViewModel loginViewModel)
        {
            loginViewModel.Password = PasswordEncryption.Encrypt(loginViewModel.Password);
            var user = await _userRepository.Login(loginViewModel);
            if(user == null)
            {
                return null;
            }
            return _mapper.Map<UserViewModel>(user);
        }
        public async Task<IEnumerable<UserViewModel>> GetAllInclude()
        {
            var users = await _userRepository.GetAllInclude(new List<string> { "Posts", "Comments", "Friends" });
            return users.Select(users => new UserViewModel
            {
                Id = users.Id,
                Name = users.Name,
                LastName = users.LastName,
                Email = users.Email,
                Photo = users.Photo,
                Password = users.Password,
                Birthdate = users.Birthdate,
                Sexo = users.Sexo,
                CountFriends = users.Friends.Count(),
                CountPosts = users.Posts.Count(),
                CountComments = users.Comments.Count(),
            });
        }
    }
}
