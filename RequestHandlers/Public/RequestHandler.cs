using Microsoft.AspNetCore.Mvc;

namespace CoffieNanny.RequestHandlers.Public;

[ApiController]
[Route("public")]
public abstract class RequestHandler : BaseRequestHandler
{
    public abstract Task Handle();
}