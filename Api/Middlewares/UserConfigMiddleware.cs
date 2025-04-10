using System.Globalization;

namespace App.Shared.Middlewares
{
    public class UserConfigMiddleware
    {
        private readonly RequestDelegate _next;

        public UserConfigMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var typeValue = httpContext.Request.Headers["Type"].FirstOrDefault();

            string UserId = httpContext.User.Claims.FirstOrDefault(c => c.Type == "user_id")?.Value;

            //Get UserId on API or Web
            httpContext.Items["UserId"] = !string.IsNullOrWhiteSpace(UserId) ? UserId : "";


            //Get Lang on API or Web
            httpContext.Items["Lang"] = string.Equals(typeValue, "Mobile", StringComparison.InvariantCultureIgnoreCase) ?
                                               httpContext.Request.Headers.AcceptLanguage.FirstOrDefault("ar") :
                                               CultureInfo.CurrentCulture.TwoLetterISOLanguageName;


            await _next(httpContext);
        }
    }


}
