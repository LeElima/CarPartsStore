using CarPartsStore.Application.Services;
using CarPartsStore.Application.Services.Interfaces;
using CarPartsStore.Data.Context;
using CarPartsStore.Data.Repositories;
using CarPartsStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPartsStore.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarPartsStoreContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("CarPartsStore"),
                    b => b.MigrationsAssembly(typeof(CarPartsStoreContext).Assembly.FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(options =>
            //         options.AccessDeniedPath = "/Account/Login");
            //Paginas web usar o AddScoped


            //var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            //services.AddMediatR(myHandlers);

            return services;

        }
        public static void ExecuteMigrations(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<CarPartsStoreContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<CarPartsStoreContext>>();
                    logger.LogError(ex, "Erro ao executar a migração do banco de dados.");
                }
            }
        }
    }
}

