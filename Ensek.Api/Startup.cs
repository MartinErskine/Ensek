using AutoMapper;
using Ensek.Api.Helpers.AutoMapperConfigs;
using Ensek.Api.Interfaces;
using Ensek.Api.Services;
using Ensek.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Ensek.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EnsekDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MeterReadingProfile());
                mc.AddProfile(new AccountProfile());
            }).CreateMapper());

            services.AddScoped<IMeterReadingService, MeterReadingService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddMvcCore().AddApiExplorer();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc(
                    "MeterReadingApi",
                    new OpenApiInfo()
                    {
                        Title = "Meter reading API",
                        Version = "1",
                        Description = "Meter reading Operations",
                        Contact = new OpenApiContact
                        {
                            Email = "someone@ensek.com",
                            Name = "Admin"
                        }
                    }
                );

                config.SwaggerDoc(
                    "AccountApi",
                    new OpenApiInfo()
                    {
                        Title = "Accounts API",
                        Version = "1",
                        Description = "Accounts Operations",
                        Contact = new OpenApiContact
                        {
                            Email = "someone@ensek.com",
                            Name = "Admin"
                        }
                    }
                );

                config.ResolveConflictingActions(apiDescriptions =>
                {
                    return apiDescriptions.First();
                });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                config.IncludeXmlComments(xmlCommentsPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/MeterReadingApi/swagger.json", "Meter Reading API");
                config.SwaggerEndpoint("/swagger/AccountApi/swagger.json", "Accounts API");

                config.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
