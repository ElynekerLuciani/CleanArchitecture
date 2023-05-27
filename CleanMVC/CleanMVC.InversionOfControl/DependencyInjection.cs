using CleanMVC.Application.Interfaces;
using CleanMVC.Application.Mappings;
using CleanMVC.Application.Services;
using CleanMVC.Domain.Interfaces;
using CleanMVC.Infra.Data.Context;
using CleanMVC.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using CleanMVC.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using CleanMVC.Domain.Account;

namespace CleanMVC.InversionOfControl
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseMySql(
               configuration.GetConnectionString("DefaultConnection"),
               Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.11-MariaDB"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
               ));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            //Alternativa para banco de dados SQLServer
            //services.AddDbContext<ApplicationDbContext>(
            //    options => options.UseSqlServer(
            //        configuration.GetConnectionString("DefaultConnection"), 
            //        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            // ));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //Adaptando para estudo de CQRS
            var myHandlers = AppDomain.CurrentDomain.Load("CleanMVC.Application");

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));

            return services;

        }
    }
}
