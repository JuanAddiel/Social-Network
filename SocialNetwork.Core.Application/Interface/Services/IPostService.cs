﻿using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interface.Services
{
    public interface IPostService:IGenericService<PostSaveViewModel, PostViewModel, Post>
    {
        Task<IEnumerable<PostViewModel>> GetAllInclude(int skip, int take);
    }
}
