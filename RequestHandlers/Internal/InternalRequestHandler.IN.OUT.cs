using CoffieNanny.RequestHandlers.Public;
using Microsoft.AspNetCore.Mvc;

namespace CoffieNanny.RequestHandlers.Internal;

[ApiController]
[Route("internal")]
public abstract class InternalRequestHandler<TIn, TOut> : BaseRequestHandler
    where TIn : class
    where TOut : class
{
    public abstract Task<TOut> Handle(TIn contract);
}