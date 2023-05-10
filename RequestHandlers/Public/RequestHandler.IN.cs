using Microsoft.AspNetCore.Mvc;

namespace CoffieNanny.RequestHandlers.Public;

[ApiController]
[Route("public")]
public abstract class InRequestHandler<TIn> : BaseRequestHandler
    where TIn : class
{
    public abstract Task Handle(TIn contract);
}