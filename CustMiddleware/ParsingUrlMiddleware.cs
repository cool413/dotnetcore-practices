using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyWebsite
{
    public class ParsingUrlMiddleware
    {
        private readonly RequestDelegate _next;

        public ParsingUrlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var queryString = context.Request.QueryString.ToString().Trim();
            var message = $"\r\n QueryString:'{queryString}'";

            await context.Response.WriteAsync($"\r\n {nameof(ParsingUrlMiddleware)} in.");
            await context.Response.WriteAsync(message);
            await _next(context);
            await context.Response.WriteAsync($"\r\n {nameof(ParsingUrlMiddleware)} out.");

        }
    }
}
