using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSite.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private IMediator _Mediator;

        protected IMediator Mediator => _Mediator ?? (_Mediator = HttpContext.RequestServices.GetService<IMediator>());        
    }
}
