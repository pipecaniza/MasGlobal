using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasGlobal.Core.Behaviors;
using MasGlobal.Core.Behaviors.Functors;
using MasGlobal.Core.DTOs;
using MasGlobal.Core.Models;
using MasGlobal.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasGlobal
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
            services.AddMvc();

            services.AddSingleton(typeof(IFunctorFactory), typeof(FunctorFactory));

            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
            services.AddScoped(typeof(IEmployeeBehavior), typeof(EmployeeBehavior));

            services.Configure<ApiConfiguration>(Configuration.GetSection("ApiConfiguration"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var functorFactory = app.ApplicationServices.GetService<IFunctorFactory>();
            functorFactory.BindFunctor(typeof(HourlySalaryEmployeeDTO), typeof(HourlySalaryFunctor));
            functorFactory.BindFunctor(typeof(MonthlySalaryEmployeeDTO), typeof(MonthlySalaryFunctor));


            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
