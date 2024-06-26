﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace OnlineStorePET.Extensions
{
    public static class CookieAuthEventsExtensions
    {
        public static void DisableRedirectionForApiClients(this CookieAuthenticationEvents events)
        {
            events.OnRedirectToLogin = ctx => SelectiveRedirect(ctx, StatusCodes.Status401Unauthorized);
            events.OnRedirectToAccessDenied = ctx => SelectiveRedirect(ctx, StatusCodes.Status403Forbidden);
            events.OnRedirectToLogout = ctx => SelectiveRedirect(ctx, StatusCodes.Status200OK);
            events.OnRedirectToReturnUrl=ctx=>SelectiveRedirect(ctx, StatusCodes.Status200OK);
        }

        private static Task SelectiveRedirect(RedirectContext<CookieAuthenticationOptions> context, int code)
        {
            if (IsApiRequest(context.Request))
            {
                context.Response.StatusCode = code;

                //Not necessarily for WPF clients
                context.Response.Headers["Location"] = context.RedirectUri;
            }
            else
            {
                context.Response.Redirect(context.RedirectUri);
            }

            return Task.CompletedTask;
        }
        private static bool IsApiRequest(HttpRequest request)
        {
            return request.Path.StartsWithSegments("/api");
        }
    }
}
