using MANAM.GlobalHealthCare.Business.Extensions;
using MANAM.GlobalHealthCare.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using MANAM.GlobalHealthCare.Common.Db;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext(configuration);

builder.Services.AddBusiness();

builder.Services.AddRepository();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, (options) =>
{
    options.LoginPath = "/Admin/Login";
    options.LogoutPath = "/Admin/Logout";
});


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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}");

app.MapAreaControllerRoute(
    name: "User_area",
    areaName: "User",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
