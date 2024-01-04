using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interface.Services;
using SocialNetwork.Core.Application.ViewModels.User;
using SocialNetwork.Middleware;

namespace SocialNetwork.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public readonly ValidationSession validationSession;
        public readonly IHttpContextAccessor httpContextAccessor;
        public UserController(IUserService userService, ValidationSession validation, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            validationSession = validation;
            this.httpContextAccessor = httpContextAccessor;

        }
        public IActionResult Index()
        {
            if (validationSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            if (validationSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = await _userService.Login(vm);
            if(user == null)
            {
                ModelState.AddModelError("Email", "Usuario o contraseña incorrecta");
                return View(vm);
            }
            httpContextAccessor.HttpContext.Session.Set<UserViewModel>("user", user);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        public IActionResult Register()
        {
            if (validationSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserSaveViewModel vm)
        {
            if (validationSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            UserSaveViewModel user = await _userService.Add(vm);
            if(vm.File != null)
            {
                user.Photo = UploadFiles.UploadImage(vm.File, user.Id, "User");
                await _userService.Update(user, user.Id);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public async Task<IActionResult> Logout()
        {
            if (!validationSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            httpContextAccessor.HttpContext.Session.Clear();

            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }
    }
}
