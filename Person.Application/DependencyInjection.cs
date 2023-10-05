﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection serviceDescriptors(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(Mapping));
            services.AddScoped<IContactService, ContactService>();


            return services;
        }
    }
}
