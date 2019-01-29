using BlogSite.Application.Posts.Commands;
using BlogSite.Application.Posts.Models;
using BlogSite.Application.Posts.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BlogSite.MVC.Controllers
{
    public sealed class PostsController : BaseController
    {
        public async Task<IActionResult> View(int blogId, int postId, CancellationToken cancellationToken)
        {
            PostDetails details = await Mediator.Send(new GetPostQuery() { PostId = postId, BlogId = blogId }, cancellationToken);
            return View(details);
        }

        public IActionResult Create(int blogId)
        {
            return View(new CreatePostCommand() { BlogId = blogId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(command);
            
            CreatePostResponse response = await Mediator.Send(command, cancellationToken);

            return RedirectToAction("View", new { blogId = response.BlogId, postId = response.PostId });
        }
    }
}
