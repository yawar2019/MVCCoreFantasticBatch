using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppToWeb
{
    public class Startup
    {
        public void ConfigureService(IServiceCollection service)
        {
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseStaticFiles();//help u to access css, js,
            app.UseEndpoints(

                endpoints =>
                    {
                        endpoints.MapGet("/", (async context =>
                         await context.Response.WriteAsync("My First Web App")
                        ));
                    });
        }
    }
}