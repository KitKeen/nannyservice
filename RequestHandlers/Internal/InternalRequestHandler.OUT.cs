using CoffieNanny.RequestHandlers.Public;
using Microsoft.AspNetCore.Mvc;

namespace CoffieNanny.RequestHandlers.Internal;

[ApiController]
[Route("internal")]
public abstract class InternalOutRequestHandler<TOUt> : BaseRequestHandler
    where TOUt : class
{
    public abstract Task<TOUt> Handle();
}