using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnesTurhan.UnluCo.Week1.Middlewares
{
    public class MyMiddleware : IMiddleware
    {
        //app.use formatında yazılır.
        //custom middleware
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

        }
    }
}
