using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace core_api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen (options =>
                options.SwaggerDoc ("v1", new Info {
                    Title = "Life Journey",
                        Version = "v1"
                })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            //   if (env.IsDevelopment () || env.IsStaging ()) {
            app.UseSwagger ();
            app.UseSwaggerUI (options =>
                options.SwaggerEndpoint ("/swagger/v1/swagger.json", "Life Journey v1")
            );
            // }

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                if (System.Diagnostics.Debugger.IsAttached) {
                    app.UseWebpackDevMiddleware (new WebpackDevMiddlewareOptions {
                        HotModuleReplacement = true
                    });
                }
            } else {
                app.UseHsts ();
            }

            app.UseStaticFiles ();

            app.UseHttpsRedirection ();
            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // routes.MapSpaFallbackRoute(
                //     name: "spa-fallback",
                //     defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}