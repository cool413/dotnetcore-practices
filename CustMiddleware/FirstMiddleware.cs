using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyWebsite
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"\r\n {nameof(FirstMiddleware)} in.");
            await _next(context);
            await context.Response.WriteAsync($"\r\n {nameof(FirstMiddleware)} out.");

        }
    }
}
