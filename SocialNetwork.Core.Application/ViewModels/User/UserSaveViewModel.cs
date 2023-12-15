using Microsoft.AspNetCore.Http;
using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.User
{
    public class UserSaveViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set;}
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Not equal")]
        public string ConfirmPassword { get; set; }
        public string? Photo { get; set; }
        public IFormFile? File { get; set; }
        public DateTime Birthdate { get; set; }
        public string Sexo { get; set; }

    }
}
