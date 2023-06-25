using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR
{
    public class TracingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Console.WriteLine("Tracing Behaviour request : " + request.ToString());
            var res = await next();
            Console.WriteLine("Tracing Behaviour response : " + res.ToString());
            return res;
        }
    }
}
