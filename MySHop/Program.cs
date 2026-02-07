using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySHop.Data;
using MySHop.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//service_dbContext_me
builder.Services.AddDbContext<MyShopContext>(Options =>
{
    Options.UseSqlServer("Data Source=HAYDEN\\HAYDEN_INSTANCE ; Initial Catalog=MyShop_Core_DB ; Integrated Security=true  ; TrustServerCertificate=True");
});

// service_Scope_me
#region IOC
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IUserRepository, UserReposirory>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

