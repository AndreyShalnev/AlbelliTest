using Albelli.BusinessLogic;
using Albelli.BusinessLogic.Interfaces;
using Albelli.Data;
using Albelli.Data.Access;
using Albelli.Data.Access.Mocks;
using Albelli.Web.Models.Interfaces;
using Albelli.Web.Models.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Albelli
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            DependencyInjection(services);
        }

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

        private void DependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IOrderMapper, OrderMapper>();
            services.AddTransient<IOrderCalculator, OrderCalculator>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddSingleton<IRepository<ProductType>, ProductTypeRepositoryMock>();
            services.AddSingleton(typeof(IRepository<>), typeof(RepositoryMock<>));
            services.AddSingleton(typeof(IGuidEntityRepository<>), typeof(GuidEntityRepositoryMock<>));
        }
    }
}
