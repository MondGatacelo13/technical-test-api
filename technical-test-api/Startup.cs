using api.common.Model;
using api.Common.Interfaces;
using api.dataccess;
using api.dataccess.EntityFramework.ProfileMapping;
using dealer.BusinessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical_test_api.Models;

namespace technical_test_api
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
            services.AddControllers().ConfigureApiBehaviorOptions(option =>
            {   
                //to suppress default modelstate invalid filter
                option.SuppressModelStateInvalidFilter = true;
            });

           
            // Add caching capabilities
            services.AddResponseCaching();
            services.AddMemoryCache();


            // Add and configure Swagger / Swashbuckler to the project
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API Technical Exam", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); 
            });

            // Add the Database context to the services at startup
            services.AddDbContext<employeetestingdbContext>(options => options.
             UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            // Create the dependency injection mappings to be used
            services.AddTransient<ICustomerBusinessLayer, CustomerBusinessLayer>();

            services.AddTransient<ICustomerDataAccess,CustomerDataAccess>();

            services.AddAutoMapper(typeof(CustomerMapper));
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable Swagger and supporting middleware
            //  - Navigate via https://{URL:Port}/api-doc/
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-doc";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Technical Exam V1");
           
            });
            app.UseHttpsRedirection();
  
        }
    }
}
