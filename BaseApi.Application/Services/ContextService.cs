using BaseApi.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace BaseApi.Application.Services
{
    public class ContextService(IHttpContextAccessor httpContextAccessor) : IContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string GetCurrentUserEmail() =>
            _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "Email")?.Value ?? string.Empty;

        public string GetCurrentUserName() =>
             _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "Name")?.Value ?? string.Empty;

        public Guid? GetCurrentUserUuid()
        {
            var userUuid = _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "Uuid")?.Value ?? string.Empty;
            return userUuid.IsNullOrEmpty() ? null : new Guid(userUuid);
        }

        public string GetHeaderValue(string headerName) =>
            _httpContextAccessor.HttpContext?.Request?.Headers[headerName].ToString() ?? string.Empty;
    }
}
