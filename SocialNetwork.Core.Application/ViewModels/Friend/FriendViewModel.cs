using SocialNetwork.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Friend
{
    public class FriendViewModel
    {
        public int Id { get; set; }
        public int UserIdFirst { get; set; }
        public int UserIdLast { get; set;}
        public string UserFirst { get; set; }
        public string UserLast { get; set; }
        public DateTime FriendshipDate { get; set; }
        public UserViewModel User { get; set; }

    }
}
