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
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Insert your name")]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Insert your last name")]
        public string LastName { get; set;}
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Insert your email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Not equal")]
        public string ConfirmPassword { get; set; }
        public string? Photo { get; set; }
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Insert your photo")]
        public IFormFile? File { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Insert your birthdate")]
        public DateTime Birthdate { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Insert your sex")]
        public string Sexo { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
