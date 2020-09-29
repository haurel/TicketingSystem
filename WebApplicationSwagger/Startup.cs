using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicketingSystem.Core;
using TicketingSystem.Core.Services;
using TicketingSystem.Services;
using TicketingSystem.Data;
using Microsoft.OpenApi.Models;
using AutoMapper;
using TicketingSystem.Data.Infrastructure;
using TicketingSystem.Core.Repositories;
using TicketingSystem.Data.Repositories;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System;
using TicketingSystem.API.Examples;
using Swashbuckle.AspNetCore.Filters;

namespace WebApplication2
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
            services.AddControllers();

            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.Formatting = Formatting.Indented;
                
            });

            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITicketService, TicketService>();


            services.AddSwaggerExamplesFromAssemblyOf<TicketExamples>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticketing System", Version = "v1" });
                //options.OperationFilter<ExamplesOperationFilter>();
                options.ExampleFilters();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My TicketingSystem V1");
            });

            
        }
    }
}
