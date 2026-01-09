namespace RiderCallAddress;

using System.Net;

public class UrlTunnelHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Return a 418 Teapot error
        // We put the URL inside the content (Body)
        var response = new HttpResponseMessage(HttpStatusCode.Ambiguous) // 300 or 418
        {
            StatusCode = (HttpStatusCode)418, // I'm a Teapot
            RequestMessage = request,
            Content = new StringContent(request.RequestUri?.ToString() ?? "")
        };

        return Task.FromResult(response);
    }
}