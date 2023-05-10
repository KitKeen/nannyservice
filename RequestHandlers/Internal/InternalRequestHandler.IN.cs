using CoffieNanny.RequestHandlers.Public;
using Microsoft.AspNetCore.Mvc;

namespace CoffieNanny.RequestHandlers.Internal;

[ApiController]
[Route("internal")]
public abstract class InternalInRequestHandler<TIn> : BaseRequestHandler
    where TIn : class
{
    public abstract Task Handle(TIn contract);
}