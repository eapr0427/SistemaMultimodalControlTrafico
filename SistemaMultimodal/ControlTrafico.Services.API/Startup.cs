using AutoMapper;
using ControlTrafico.Application.Services;
using ControlTrafico.Data.Domain.Repositories;
using ControlTrafico.Data.EF.Core;
using ControlTrafico.Data.EF.Core.Repositories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace ControlTrafico.Services.API
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
            //Register Swagger Generator
            services.AddSwaggerGen(mm =>
            {
                mm.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sistema de Control de Tráfico",
                    Version = "v1",
                    Description = "Arquitectura de Software - Sistema Multimodal"
                    //Contact = new InfoContact
                    //{
                    //    Name = "Poli",
                    //    Email = string.Empty,
                    //    Url = new Uri("https://www.globant.com")
                    //}
                });

            });

            InitDbContext(services);
            RegisterRepositories(services);
            RegisterServices(services);

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Control Tráfico API - Dream Team V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFlujoService, FlujoService>();
        }
        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IFlujoRepository, FlujoRepository>();
        }
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        //    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        //    {
        //        var context = serviceScope.ServiceProvider.GetRequiredService<UnitOfWork>();
        //        context.Database.EnsureCreated();
        //    }

        //    app.UseMvc();
        //}
        private void InitDbContext(IServiceCollection services)
        {
            services.AddDbContext<UnitOfWork>(opts =>
                opts.UseSqlServer(Configuration["ConnectionString:SistemaMultimodalDB"]));
        }

    }
}
