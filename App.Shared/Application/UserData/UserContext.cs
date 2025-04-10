using Microsoft.AspNetCore.Http;

namespace App.Shared.Application.UserData
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.Items["UserId"] as string ?? "";

        public string Lang => _httpContextAccessor.HttpContext?.Items["Lang"] as string ?? "";
    }
}
