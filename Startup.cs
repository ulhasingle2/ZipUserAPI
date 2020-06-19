using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZipUserAPI.Data;
using ZIPUSERAPI.Data;

namespace ZipUserAPI
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
            var server= Configuration["DBServer"] ?? "ms-sql-server";
            var port= Configuration["DBPort"] ?? "1443";
            var user= Configuration["DBUser"] ?? "sa";
            var password= Configuration["DBPassword"] ?? "Passw0rd@2019";
            var database= Configuration["Database"] ?? "ZipDB";
            

            services.AddDbContext<UserContext>(
                opt =>opt.UseSqlServer($"Server={server};Database={database};User ID={user};Password={password}"));
           
           
           // services.AddDbContext<UserContext>(
           //     opt =>opt.UseSqlServer($"Server={server};Database={database};Integrated Security=SSPI;persist security info=True;"));


            //This below is used to fetch connection string from application.json file
            // services.AddDbContext<UserContext>(opt =>opt.UseSqlServer
            // (Configuration.GetConnectionString("UserConnection")));

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
           // services.AddScoped<IUserRepo,UserRepo>();
           services.AddScoped<IUserRepo,UserRepos>();
           services.AddScoped<IAccountRepo,AccountRepo>();
           
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
        }
    }
}
