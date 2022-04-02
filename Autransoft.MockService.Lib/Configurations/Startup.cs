using Autransoft.MockService.Lib.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autransoft.MockService.Lib.Configurations
{
    ///<Summary>
    /// 
    ///</Summary>
    internal class Startup
    {
        ///<Summary>
        /// 
        ///</Summary>
        public IConfiguration Configuration { get; }

        ///<Summary>
        /// 
        ///</Summary>
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        ///<Summary>
        /// 
        ///</Summary>
        public void ConfigureServices(IServiceCollection services) => 
            services.AddControllers();

        ///<Summary>
        /// 
        ///</Summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<RequestMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}