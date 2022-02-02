using CMS_Api_Raag.Models;
using CMS_Api_Raag.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag
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

            // Connection string for DB injet as dependency
            services.AddDbContext<CMSDBContext>(db =>
            db.UseSqlServer(Configuration.GetConnectionString("CMSDBConnection")));


            // add dependency injection of Pharmacist repo
            services.AddScoped<IPharmacistRepository, PharmacistRepository>();
            services.AddScoped<ILabTechRepository, LabTechRepository>();
            

            // adding services
            services.AddControllers().AddNewtonsoftJson(
                options => {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                }
                );

            services
                .AddControllers().AddNewtonsoftJson(
                options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // add db injection here


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
