using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SampleCore.Data.UnitofWork;
using SampleCore.Service.Interfaces;
using SampleCore.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCore.Framework.System
{
    public static class DependencyResolver
    {
        public static void Build(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUnitofWork, UnitofWork>();

            services.AddScoped<IUtilityService, UtilityService>();
            services.AddScoped<ISampleCoreService, SampleCoreService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ILogService, LogService>();
        }
    }
}
