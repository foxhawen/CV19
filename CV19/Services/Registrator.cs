﻿using CV19.Services.Interfaces;
using CV19.Services.Students;
using Microsoft.Extensions.DependencyInjection;

namespace CV19.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            //services.AddTransient<IDataService, DataService>();
            //services.AddScoped<IDataService, DataService>();

            services.AddTransient<IAsyncDataService, AsyncDataService>();
            services.AddTransient<IWebServerService, HttpListnerWebServerer>();

            services.AddSingleton<StudentsRepository>();
            services.AddSingleton<GroupsRepository>();
            services.AddSingleton<StudentsManager>();

            return services;
        }
    }
}
