using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWebsite.Controllers;
using MyWebsite.Extensions;
using MyWebsite.Services;

namespace MyWebsite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Program.Output("Startup Constructor - Called");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Program.Output("Startup.ConfigureServices - Called");
            services.AddControllersWithViews();

            #region DI
            //Controller
            services.AddTransient<ISampleTransient, Sample>();
            services.AddScoped<ISampleScoped, Sample>();
            services.AddSingleton<ISampleSingleton, Sample>();
            // Singleton 也可以用以下方法註冊
            // services.AddSingleton<ISampleSingleton>(new Sample());

            //Service
            services.AddScoped<InjectionService, InjectionService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            //Middleware
            //app.UseMiddleware();

            #region appLifetime
            appLifetime.ApplicationStarted.Register(() =>
            {
                Program.Output("ApplicationLifetime - Started");
            });

            appLifetime.ApplicationStopping.Register(() =>
            {
                Program.Output("ApplicationLifetime - Stopping");
            });

            appLifetime.ApplicationStopped.Register(() =>
            {
                Thread.Sleep(5 * 1000);
                Program.Output("ApplicationLifetime - Stopped");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("\r\n Hello World!");
            //});

            // For trigger stop WebHost
            //var thread = new Thread(new ThreadStart(() =>
            //{
            //    Thread.Sleep(5 * 1000);
            //    Program.Output("Trigger stop WebHost");
            //    appLifetime.StopApplication();
            //}));
            //thread.Start();

            Program.Output("Startup.Configure - Called");
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
