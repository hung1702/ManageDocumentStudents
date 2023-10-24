using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ManageStudents.API.Application.Authorization
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private const string ACCESS_TOKEN = "access_token";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpClientAuthorizationDelegatingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var authorizationHeader = _httpContextAccessor.HttpContext
                    .Request.Headers["Authorization"];

                if (!string.IsNullOrEmpty(authorizationHeader))
                {
                    request.Headers.Add("Authorization", new List<string>() { authorizationHeader! });
                }

                var token = await GetToken();
                if (token != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string?> GetToken()
        {
            if(_httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                return await _httpContextAccessor.HttpContext.GetTokenAsync(ACCESS_TOKEN);
            }
            return null;
        }
    }
}
