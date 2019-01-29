using BlogSite.Application.Blogs.Commands;
using BlogSite.Application.Blogs.Models;
using BlogSite.Application.Blogs.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlogSite.MVC.Controllers
{
    public sealed class BlogsController : BaseController
    {   
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            IEnumerable<BlogPreview> blogs = await Mediator.Send(new GetAllBlogPreviewsQuery(), cancellationToken);
            return View(blogs);
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            BlogDetails details = await Mediator.Send(new GetBlogDetailsQuery() { BlogId = id }, cancellationToken);
            return View(details);
        }

        public IActionResult Create(CancellationToken cancellationToken)
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBlogCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(command);

            CreateBlogResponse response = await Mediator.Send(command, cancellationToken);

            return RedirectToAction(nameof(Details), new { id = response.BlogId });
        }
    }
}