using Microsoft.Extensions.Primitives;

namespace BlogBackend.Middleware
{
    /// <summary>
    /// Authentication middleware.
    /// </summary>
    public class AuthMiddleware : IMiddleware
    {
        private const string API_KEY_NAME = "ApiKey";
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public AuthMiddleware(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string? path = context.Request.Path.Value;
            if (string.IsNullOrWhiteSpace(path))
            {
                await next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(API_KEY_NAME, out StringValues apiKey) || !apiKey.Equals(_configuration["ApiKey"]))
            {
                context.Response.StatusCode = 401;
                return;
            }

            await next(context);
        }
    }
}
