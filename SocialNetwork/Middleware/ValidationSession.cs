using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.ViewModels.User;

namespace SocialNetwork.Middleware
{
    public class ValidationSession
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ValidationSession(IHttpContextAccessor httpContext)
        {
            _contextAccessor = httpContext;
        }

        public bool HasUser()
        {
            var user = _contextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            if(user == null)
            {
                return false;
            }
            return true;
        }
    }
}
