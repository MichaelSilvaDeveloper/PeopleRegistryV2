using Application.Application;
using Application.Interfaces;
using Domain.Interfaces.Generic;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Infrastructure.Repository.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_Registry
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
            services.AddDbContext<PeopleRegistryDBContext>(options => options.UseSqlServer(
                    Configuration.GetConnectionString("DataBase")));


            //services.AddEntityFrameworkSqlServer()
            //    .AddDbContext<PeopleRegistryDBContext>
            //    (options => options.UseSqlServer(Configuration.GetConnectionString("Database")));


            services.AddDbContext<PeopleRegistryDBContext>(options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<Person>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<PeopleRegistryDBContext>();




            services.AddSingleton(typeof(IGeneric<>), typeof(GenericRepository<>));
            services.AddScoped<IPerson, PersonRepository>();
            services.AddScoped<IPersonApplication, PersonApplication>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "People_Registry", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "People_Registry v1"));
            }

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
