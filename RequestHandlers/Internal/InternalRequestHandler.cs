using Microsoft.AspNetCore.Mvc;

namespace CoffieNanny.RequestHandlers.Internal;

[ApiController]
[Route("internal")]
public abstract class InternalRequestHandler : InternalBaseRequestHandler
{
    public abstract Task Handle();
}