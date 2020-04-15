using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace MyWebsite.Extensions
{
    public static class CustomMiddlewareExtensions
    {
        public static void UseMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<FirstMiddleware>();
            builder.UseMiddleware<ParsingUrlMiddleware>();
        }
    }
}
