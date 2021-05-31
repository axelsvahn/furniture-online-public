using Inredning.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Inredning
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
            //inmemory database
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("inredning"));

            //identity core
            services.AddDefaultIdentity<User>().AddEntityFrameworkStores<AppDbContext>();

            //classes
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddHttpContextAccessor();

            //shopping cart stuff, not used right now 
            //services.AddSession();

            services.AddControllersWithViews();//mvc
            services.AddRazorPages(); //needed for identity core
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            //app.UseSession(); //used for shopping cart,  will not need it
            app.UseRouting();
            app.UseAuthentication(); //needed for identity core
            app.UseAuthorization();//needed for identity core

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages(); //needed for identity core
            });
        }
    }
}
