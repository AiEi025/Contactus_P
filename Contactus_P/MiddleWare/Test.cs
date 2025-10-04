using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Contactus_P.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Test
    {
        private readonly RequestDelegate _next;

        public Test(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Custommiddle", "Test");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TestExtensions
    {
        public static IApplicationBuilder UseTest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Test>();
        }
    }
}
