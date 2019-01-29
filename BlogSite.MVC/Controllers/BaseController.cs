using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSite.MVC.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        private IMediator _Mediator;

        protected IMediator Mediator => _Mediator ?? (_Mediator = HttpContext.RequestServices.GetService<IMediator>());        
    }
}
