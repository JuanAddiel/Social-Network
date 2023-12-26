using AutoMapper;
using SocialNetwork.Core.Application.ViewModels.Comment;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Application.ViewModels.User;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Mappings
{
    public class GeneralProfile :Profile
    {
        public GeneralProfile()
        {

            #region PostMapping
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.NameUser, opt => opt.Ignore())
                .ForMember(dest => dest.LastNameUser, opt => opt.Ignore())
                .ForMember(dest => dest.ImgUrlUser, opt => opt.Ignore())
                .ForMember(dest => dest.CommentsCount, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());

            CreateMap<Post, PostSaveViewModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.comments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());
            #endregion

            #region FriendMapping
            CreateMap<Friend, FriendViewModel>()
                .ForMember(dest => dest.UserFirst, opt => opt.Ignore())
                .ForMember(dest => dest.UserLast, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());

            CreateMap<Friend, FriendSaveViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());
            #endregion

            #region CommentMapping
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.NameUser, opt => opt.Ignore())
                .ForMember(dest => dest.LastNameUser, opt => opt.Ignore())
                .ForMember(dest => dest.ImgUrlUser, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());

            CreateMap<Comment, CommentSaveViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Post, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());
            #endregion

            #region UserMapping
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.CountFriends, opt => opt.Ignore())
                .ForMember(dest => dest.CountPosts, opt => opt.Ignore())
                .ForMember(dest => dest.CountComments, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());
            
            CreateMap<User, UserSaveViewModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Friends, opt => opt.Ignore())
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());

            #endregion
        }
    }
}
