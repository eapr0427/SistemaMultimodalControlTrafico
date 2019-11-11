using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using ControlTrafico.Presentation.Admin.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ControlTrafico.ExternalServices.Services;
using AutoMapper;
using ControlTrafico.Data.EF.Core.Repositories.Implementations;
using ControlTrafico.Data.Domain.Repositories;
using ControlTrafico.Data.EF.Core;
using ControlTrafico.Application.Services.Contracts;
using ControlTrafico.Application.Services;

namespace ControlTrafico.Presentation.Admin
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
            InitDbContext(services);
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("SistemaMultimodalDB")));
           
            services.AddControllersWithViews();
            services.AddRazorPages();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            RegisterServices(services);
            RegisterRepositories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<IEstacionService, EstacionService>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IEstacionRepository, EstacionRepository>();
        }
        private void InitDbContext(IServiceCollection services)
        {
            var DbContext = services.AddDbContext<UnitOfWork>(opts =>
                  opts.UseSqlServer(Configuration["ConnectionString:SistemaMultimodalDB"]));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<UnitOfWork>();
        }
    }
}
