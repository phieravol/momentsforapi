
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace MomentsFor.Application.Behaviors
{
    public class PerformancePipelineBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;

        public PerformancePipelineBehavior(Stopwatch timer, ILogger<TRequest> logger)
        {
            this.timer = timer;
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            timer.Start();
            var response = await next();
            timer.Stop();
            
            var elapsedMiliseconds = timer.ElapsedMilliseconds;

            if (elapsedMiliseconds <= 1000)
            {
                return response;
            }
            var requestName = typeof(TRequest).Name;
            logger.LogWarning("Long time running - Request detail: {name} ({ElapsedMilliseconds} miliseconds) {@Request}", 
                requestName, elapsedMiliseconds, request);
            return response;
        }
    }
}
