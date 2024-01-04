using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interface.Services;
using SocialNetwork.Core.Application.ViewModels.Post;
using SocialNetwork.Core.Application.ViewModels.User;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Middleware;
using SocialNetwork.Core.Application.Services;
using SocialNetwork.Core.Domain.Entities;

namespace SocialNetwork.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ValidationSession _validation;
        public readonly IHttpContextAccessor _contextAccessor;
        public PostController(IPostService postService, ValidationSession validation, IHttpContextAccessor httpContext)
        {
            _postService = postService;
            _validation = validation;
            _contextAccessor = httpContext;
        }
        public async Task<IActionResult> Index(int skip = 0, int take = 10)
        {
            return View(await _postService.GetAllInclude(skip, take));
        }
        public async Task<IActionResult> Create()
        {
            if (!_validation.HasUser())
                return RedirectToRoute(new { controller = "User", action = "Index" });

            PostSaveViewModel vm = new();
            vm.UserId = _contextAccessor.HttpContext.Session.Get<UserViewModel>("user").Id;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostSaveViewModel vm)
        {
            if (!_validation.HasUser())
                return RedirectToRoute(new { controller = "User", action = "Index" });

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            PostSaveViewModel post = await _postService.Add(vm);
            if (vm.File != null)
            {
                post.ImgUrl = UploadFiles.UploadImage(vm.File, post.Id, "Post");
                await _postService.Update(post, post.Id);
            }
            return RedirectToRoute(new { controller = "Post", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validation.HasUser())
                return RedirectToRoute(new { controller = "User", action = "Index" });

            PostSaveViewModel vm = await _postService.GetById(id);
            return View("Create",vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PostSaveViewModel vm)
        {
            if (!_validation.HasUser())
                return RedirectToRoute(new { controller = "User", action = "Index" });

            if (!ModelState.IsValid)
            {
                return View("Create",vm);
            }
      
            if (vm.File != null)
            {
                vm.ImgUrl = UploadFiles.UploadImage(vm.File, vm.Id, "Post");
                await _postService.Update(vm, vm.Id);
            }
            else
            {
                await _postService.Update(vm, vm.Id);

            }

            return RedirectToRoute(new { controller = "Post", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_validation.HasUser())
                return RedirectToRoute(new { controller = "User", action = "Index" });

            await _postService.Delete(id);

            return RedirectToRoute(new { controller = "Post", action = "Index" });
        }

    }
}
