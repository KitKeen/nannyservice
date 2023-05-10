using Microsoft.AspNetCore.Mvc;

namespace CoffieNanny.RequestHandlers.Public;

[ApiController]
[Route("public")]
public abstract class OutRequestHandler<TOut> : BaseRequestHandler
    where TOut : class
{
    public abstract Task<TOut> Handle();
}