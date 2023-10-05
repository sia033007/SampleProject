using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Person.Application;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementDataInject(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ContactDbContext>(o => o.UseSqlServer(configuration.GetConnectionString
                ("DefaultConnection"), b => b.MigrationsAssembly("Person.MVC")), ServiceLifetime.Transient);

            services.AddScoped<IContactDbContext>(provider =>
            provider.GetRequiredService<ContactDbContext>());
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddAutoMapper(typeof(Mapping));

            return services;
        }
    }
}
