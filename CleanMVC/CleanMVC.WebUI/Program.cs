using CleanMVC.Domain.Account;
using CleanMVC.Infra.Data.Identity;
using CleanMVC.InversionOfControl;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

//seedUserRoleInitial.SeedRoles();
//seedUserRoleInitial.SeedUsers();
SeedUserRoles(app);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var seed = serviceScope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        seed.SeedUsers();
        seed.SeedRoles();
    }
}

//using CleanMVC.Domain.Account;
//using CleanMVC.InversionOfControl;
//using CleanMVC.WebUI;
//using System.Runtime.CompilerServices;

//var builder = WebApplication.CreateBuilder(args);

//var startup = new Startup(builder.Configuration);
//startup.ConfigureServices(builder.Services);

//var app = builder.Build();

//startup.Configure(app, app.Environment);

//app.Run();