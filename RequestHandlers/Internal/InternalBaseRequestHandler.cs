using System.Net;
using Microsoft.Extensions.Primitives;

namespace CoffieNanny.RequestHandlers.Internal;

public class InternalBaseRequestHandler
{
    public IDictionary<string, StringValues> RequestHeaders { get; set; } = new Dictionary<string, StringValues>();
    public IDictionary<string, StringValues> ResponseHeaders { get; set; } = new Dictionary<string, StringValues>();
    public IEnumerable<KeyValuePair<string, string>> RequestCookies { get; set; }
        = new List<KeyValuePair<string, string>>();
    public CookieCollection ResponseCookies { get; set; } = new();
    public CancellationToken CancellationToken { get; set; }
    public Stream ResponseBody { get; set; }
}