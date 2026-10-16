using System.Net;

namespace API.Clients
{
    public class SesionExpiradaHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized && request.Headers.Authorization != null)
            {
                ApiClient.MarcarSesionVencida();
            }

            return response;
        }
    }
}