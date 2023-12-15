using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Friend
{
    public class FriendSaveViewModel
    {
        public int Id { get; set; }
        public int UserIdFirst { get; set; }
        public int UserIdLast { get; set;}
        public DateTime FriendshipDate { get; set; }
    }
}
