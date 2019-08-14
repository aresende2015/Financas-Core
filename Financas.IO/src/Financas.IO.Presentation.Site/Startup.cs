using AutoMapper;
using Financas.IO.Domain.Interfaces;
using Financas.IO.Infra.CrossCutting.Bus;
using Financas.IO.Infra.CrossCutting.Identity.Data;
using Financas.IO.Infra.CrossCutting.Identity.Models;
using Financas.IO.Infra.CrossCutting.Identity.Services;
using Financas.IO.Infra.CrossCutting.IoC;
using Financas.IO.Infra.Data2.Context;
using Financas.IO.Infra.Data2.Initializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Financas.IO.Presentation.Site
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("PodeLerEventos", policy => policy.RequireClaim("Eventos", "Ler"));
            //    options.AddPolicy("PodeGravar", policy => policy.RequireClaim("Eventos", "Gravar"));
            //});

            services.AddLogging();

            services.AddMvc();

            services.AddAutoMapper();

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new ServiceFilterAttribute(typeof(GlobalExceptionHandlingFilter)));
            //    options.Filters.Add(new ServiceFilterAttribute(typeof(GlobalActionLogger)));
            //});

            

            RegisterServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env, 
                              ILoggerFactory loggerFactory,
                              IHttpContextAccessor accessor)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;


            //// Para iniciar a tabela de Cidades
            ////using (var dbContext = new FinancaEFContext())
            ////{
            ////    DbInitializer.Initializer(dbContext);
            ////}

        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
