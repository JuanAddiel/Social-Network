using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.ViewModels.Comment
{
    public class CommentSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Requerido")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
