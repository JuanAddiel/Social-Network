using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interface.Services;
using SocialNetwork.Core.Application.ViewModels.Comment;

namespace SocialNetwork.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IActionResult> Index(int postId, int skip = 0, int take = 3)
        {
            if (postId == 0)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            ViewBag.Take = take;
            ViewBag.Skip = skip;
            return View(await _commentService.GetAllInclude(postId, skip, take));
        }
        [HttpPost]
        public async Task<IActionResult> Create(string msg, int userId, int postId)
        {
            CommentSaveViewModel vm = new();
            vm.UserId = userId;
            vm.PostId = postId;
            vm.Content = msg;
            if (!ModelState.IsValid)
            {
                return View("Index",vm);
            }
            await _commentService.Add(vm);

            return RedirectToAction("Index", new { postId = postId });
        }
    }
}
