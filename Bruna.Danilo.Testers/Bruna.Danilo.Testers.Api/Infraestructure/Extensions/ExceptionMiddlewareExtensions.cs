using System;
using System.Net;
using Bruna.Danilo.Testers.Logs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;

namespace Bruna.Danilo.Testers.Api.Infraestructure.Extensions
{
	public static class ExceptionMiddlewareExtensions
    {
		public static void ConfigureExceptionHandler(this IApplicationBuilder app, Logger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
						await logger.ErrorAsync(contextFeature.Error, "");
                    }
                });
            });
        }
    }
}
