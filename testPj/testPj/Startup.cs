using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Helpers.Module;
using testPj.Repo;
using testPj.Repo.Interface;
using testPj.Services;
using testPj.Services.Interface;

namespace testPj
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
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            //GlobalSetting.Secret = jwtSettings.Secret;

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromDays(8);
            });
            services.AddControllersWithViews();

            //var sqlConnectionString = Configuration["ConnectionStrings:SqlDbConnectionString"];
            //services.AddDbContext<SqlDbContext>(options => options.UseNpgsql(sqlConnectionString));

            services.AddDbContext<SqlDbContext>(options => options.UseMySql(Configuration.GetConnectionString("SqlDbConnectionString"), MySqlServerVersion.LatestSupportedServerVersion));
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddSession();
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

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
