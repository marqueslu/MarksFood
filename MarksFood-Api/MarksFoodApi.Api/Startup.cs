﻿using MarksFoodApi.Domain.Interfaces.Services;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Domain.Services;
using MarksFoodApi.Infra.Context;
using MarksFoodApi.Infra.DbSettings;
using MarksFoodApi.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace MarksFoodApi.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                .Build());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<MarksFoodApiDbContext, MarksFoodApiDbContext>();
            services.AddTransient<ISnackRepository, SnackRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<ISnackService, SnackService>();
            services.AddTransient<IIngredientService, IngredientService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "MarksFood",
                        Version = "v1",
                        Contact = new Contact
                        {
                            Name = "Lucas Marques",
                            Url = "https://github.com/marqueslu"
                        }
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarksFood V1");
                c.RoutePrefix = string.Empty;

            });


            Settings.ConnectionString = Configuration.GetConnectionString("CnnStr");
        }
    }
}
