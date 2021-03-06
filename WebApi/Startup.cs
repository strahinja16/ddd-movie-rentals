﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Core.Interfaces.Infrastructure;
using Core.Services;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApi.Interfaces;
using WebApi.Mappings;
using WebApi.Middlewares;
using WebApi.Seeds;
using WebApi.Services;

namespace DDD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RentalDbContext>(o => o.UseSqlServer(
                    Configuration.GetConnectionString("SqlServer"),
                    b => b.MigrationsAssembly("WebApi")
                ));

            // infrastructure repositories
            services.AddTransient<IMoviesRepository, MoviesRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();

            // application services
            services.AddTransient<IMoviesService, MoviesService>();
            services.AddTransient<ICustomersService, CustomersService>();

            // domain services
            services.AddTransient<IMovieAcquisitionService, MovieAcquisitionService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IStreamingService, StreamingService>();
            services.AddTransient<IDomainCustomersService, DomainCustomersService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvc();

            //SeedData.SeedDatabase(serviceProvider.GetRequiredService<RentalDbContext>());
        }
    }
}
