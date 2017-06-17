using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MvcMovies.Models;

namespace MvcMovies
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<MvcMoviesContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MvcMoviesContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
     

            // UseMvc add an instance of RouterMiddleware in the middleware pipeline bleow. 
            // Example of Conventional routing because establishes a convention for URL paths.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    // MVC invokes controller classes (and the action methods within them) depending on the incoming URL
                    // The default URL routing logic used by MVC uses a format like this to determine what code to invoke: Therefore the HomeController Action Index is the default route.

                    // First path segment maps to the controller name, the second maps to action name, third segment optional ID used to map to model entity.
                    //         [Controller]/     [ActionName]/  [Parameters]
                    template: "{controller=Home}/{action=Index}/{id?}");  // the ? indicates parameter is optional.
                // This mapping is based on the controller and action names only. Example Using this default route, the URL path /Products/List maps to the ProductsController.List action, and /Blog/Article/17 maps to BlogController.Article

            });
        }
    }
}
