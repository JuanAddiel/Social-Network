using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Photo { get; set; }
        public string Sexo { get; set; }
        public int CountFriends { get; set; }
        public int CountPosts { get; set; }
        public int CountComments { get; set; }

        public ICollection<FriendViewModel> Friends { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }

    }
}
