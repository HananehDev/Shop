namespace MySHop.EndPoints
{
    public static class AdminEndPoints
    {
        public static async Task MyHandler(IApplicationBuilder app)
        {
            app.Use(async (context,next) =>
            {
                if (!context.User.Identity.IsAuthenticated)
                {
                    context.Response.Redirect("/Account/Login");
                }
                else
                {
                    await next.Invoke();
                }
            });
        }
    }
}

