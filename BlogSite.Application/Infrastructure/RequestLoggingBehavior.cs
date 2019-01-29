using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlogSite.Application.Infrastructure
{
    public sealed class RequestLoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>        
    {
        private readonly ILogger _logger;

        public RequestLoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;
            _logger.LogInformation("BlogSite Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}
