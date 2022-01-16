using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        ///<Summary>
        /// 
        ///</Summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        ///<Summary>
        /// 
        ///</Summary>
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