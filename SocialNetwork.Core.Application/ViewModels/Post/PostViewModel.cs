using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string NameUser { get; set; }
        public string LastNameUser { get; set; }
        public string ImgUrlUser { get; set; }
        public int CommentsCount { get; set; }
        public DateTime PostDate { get; set; }
        public UserViewModel User { get; set; }
        public ICollection<CommentViewModel> comments { get; set; }

    }
}
