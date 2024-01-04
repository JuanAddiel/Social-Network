using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string NameUser { get; set; }
        public string LastNameUser { get; set; }
        public string ImgUrlUser { get; set; }
        public DateTime? CreatedAt { get; set; }
        public UserViewModel User { get; set; }
        public PostViewModel Post { get; set; }
    }
}
