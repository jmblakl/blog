using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlogSite.Application.Infrastructure
{
    public sealed class RequestLoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : IApplicationRequest
    {
        private readonly ILogger _logger;

        public RequestLoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;
            IUserContext user = request.User;
            _logger.LogInformation("BlogSite Request: {Name} {@Request} {@User}", name, request, user);

            return Task.CompletedTask;
        }
    }
}
