using Employees.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.Data.Repository.Implementations;
using Employees.Data.Repository;
using Employees.Services;
using Employees.Services.Services;
using Employees.Services.Services.Implementations;

namespace Employees
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Используйте этот метод для добавления сервисов 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchoolContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Employees.Data")));
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseService, CourseService>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentService, StudentService>();

            
            //предоставляет полезные сведения об ошибках в среде разработки
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews();
        }
        // Используйте этот метод для настройки запросов HTTP
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
