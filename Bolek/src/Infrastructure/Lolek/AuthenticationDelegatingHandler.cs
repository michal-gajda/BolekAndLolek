namespace Bolek.Infrastructure.Lolek;

internal sealed class AuthenticationDelegatingHandler(LolekOptions options) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Authorization", options.AccessToken);

        return base.SendAsync(request, cancellationToken);
    }
}
