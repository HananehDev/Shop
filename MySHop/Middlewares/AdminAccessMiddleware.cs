using System.Security.Claims;

namespace MyShop.Middlewares
{
    public class AdminAccessMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/Admin"))
            {
                // اگر لاگین نیست → Login با returnUrl
                if (!context.User.Identity?.IsAuthenticated ?? true)
                {
                    context.Response.Redirect($"/Account/Login?returnUrl={context.Request.Path}");
                    return;
                }

                // اگر لاگین هست ولی Admin نیست → پیام دسترسی ندارید
                var isAdminClaim = context.User.FindFirst("IsAdmin");
                if (isAdminClaim == null || isAdminClaim.Value != "True")
                {
                    context.Response.Redirect("/Account/Login?error=accessdenied");
                    return;
                }
            }
            if (context.Request.Path.StartsWithSegments("/Admin"))
            {
                if (!context.User.Identity?.IsAuthenticated ?? true ||
                    context.User.FindFirst("IsAdmin")?.Value != "True")
                {
                    context.Response.Redirect("/Account/Login?error=accessdenied");
                    return;
                }
            }
            await _next(context);
        }
    }
}