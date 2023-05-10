using Microsoft.AspNetCore.Mvc;

namespace CoffieNanny.RequestHandlers.Public;

[ApiController]
[Route("public")]
public abstract class RequestHandler<TIn, TOut> : BaseRequestHandler
    where TIn : class
    where TOut : class
{
    public abstract Task<TOut> Handle(TIn contract);
}