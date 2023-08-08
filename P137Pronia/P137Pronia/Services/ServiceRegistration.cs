﻿using System;
using P137Pronia.ExtensionServices.Implements;
using P137Pronia.ExtensionServices.Interfaces;
using P137Pronia.Services.Implements;
using P137Pronia.Services.Interfaces;

namespace P137Pronia.Services
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<LayoutService>();
        }
    }
}
