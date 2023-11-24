using SocialNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Domain.Entities
{
    public class Friend:AuditableBaseEntity
    {
        public int UserIdFirst { get; set; }
        public int UserIdLast { get; set;}
        public User User { get; set; }
        public DateTime FriendshipDate { get; set; }

    }
}
