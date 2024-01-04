using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interface.Services;
using SocialNetwork.Core.Application.ViewModels.Friend;
using SocialNetwork.Core.Application.ViewModels.User;

namespace SocialNetwork.Controllers
{
    public class FriendController : Controller
    {
        private readonly IFriendService _service;
        private readonly IHttpContextAccessor _contextAccessor;
        public FriendController(IFriendService service, IHttpContextAccessor httpContext)
        {
            _service = service;
            _contextAccessor = httpContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(int idUser)
        {
            FriendSaveViewModel vm = new();
            vm.UserIdLast = idUser;
            vm.FriendshipDate = DateTime.Now;
            vm.UserIdFirst = _contextAccessor.HttpContext.Session.Get<UserViewModel>("user").Id;
            await _service.Add(vm);
            return RedirectToRoute(new { controller = "Post", action = "Index" });
        }
    }
}
