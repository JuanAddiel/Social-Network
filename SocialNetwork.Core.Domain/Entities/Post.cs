using SocialNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Post: AuditableBaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string? imgUrl { get; set; }
        public string Content { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}
