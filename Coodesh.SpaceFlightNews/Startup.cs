using AutoMapper;
using Coodesh.SpaceFlightNews.Services;
using Coodesh.SpaceFlightNews.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Coodesh.SpaceFlightNews.Interfaces.Repository;
using Coodesh.SpaceFlightNews.Interfaces.Services;
using Quartz.Spi;
using Quartz;
using Quartz.Impl;
using Coodesh.SpaceFlightNews.Jobs;
using Coodesh.SpaceFlightNews.DTO;
using Microsoft.OpenApi.Models;
using System;

namespace Coodesh.SpaceFlightNews.Web
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
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }).CreateMapper());

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IDataFromAPIService, GetDataFromAPIService>();

            // Add Quartz services
            services.AddHostedService<QuartzHostedService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            // Add our job
            services.AddSingleton<UpdateDatabaseJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(UpdateDatabaseJob),
                cronExpression: "0 0 9 * * ?"));


            services.AddRazorPages();
            services.AddMvcCore().AddApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Spaceflight News API",
                    Version = "v1",
                    Description = "API p&uacute;blica com informa&ccedil;&otilde;es relacionadas a voos espaciais.",
                    Contact = new OpenApiContact
                    {
                        Name = "Gabriel Machado",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/gcm10000")
                    },
                });
            });

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spaceflight News API V1");

                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Rotas
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{ID?}");
                endpoints.MapControllers();
            });
        }
    }
}
