using SocialNetwork.Core.Application.Interface.Repositories;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Infrastructured.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructured.Persistence.Repository
{
    public class CommentRepository:GenericRepository<Comment>,ICommentRepository
    {
        private readonly ApplicationContext _context;
        public CommentRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }
    }
}
