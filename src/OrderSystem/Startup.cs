using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderSystem.DataModels;
using OrderSystem.Models;
using OrderSystem.Services;
using Shared.Middleware;

namespace OrderSystem
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
            services.AddControllers();
            services.AddTransient<IOrderService, OrderService>();
            services.Configure<OrderDataSettings>(Configuration.GetSection("OrderDataSettings"));
            services.AddSingleton<IOrderDataSettings>(sp =>
            {
                var b = sp.GetRequiredService<IOptions<OrderDataSettings>>();

                return b.Value;
            });
            services.AddDbContext<OrderDbContext>((sp,x) =>
            {
                var configs = sp.GetRequiredService<IOrderDataSettings>(); 
                x.UseNpgsql(configs.ConnectionString)
                 .EnableSensitiveDataLogging()
                 .EnableDetailedErrors(); 
            });
            services.AddTransient<IItemService, ItemService>();
            services.AddLogging(x => x.AddConsole().AddDebug());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<RequestLogMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
