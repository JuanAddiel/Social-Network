using AutoMapper;
using SocialNetwork.Core.Application.Interface.Repositories;
using SocialNetwork.Core.Application.Interface.Services;
using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class FriendService:GenericService<FriendSaveViewModel,FriendViewModel, Friend>, IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;
        public FriendService(IFriendRepository friendRepository, IMapper mapper):base(friendRepository,mapper)
        {
            _friendRepository = friendRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FriendViewModel>> GetAllInclude()
        {
            var friends = await _friendRepository.GetAllInclude(new List<string> {"User"});
            return friends.Select(friends => new FriendViewModel
            {
                Id = friends.Id,
                UserIdFirst = friends.UserIdFirst,
                UserIdLast = friends.UserIdLast,
                UserFirst = friends.User.Name,
                UserLast = friends.User.Name,
                FriendshipDate = friends.FriendshipDate,
            });
        }
    }
}
