using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Data;
using API.Services;
using API.Configuration;
using System.Net.Http;

namespace API
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
            // Configure your database context here
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Register AppSettings from appsettings.json
            var appSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);
            services.AddSingleton(appSettings);

            // Register HttpClient for the AuthenticationService
            services.AddHttpClient<AuthenticationService>();

            // Add services and other configurations here
            services.AddScoped<ITokenStorageService, TokenStorageService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPortfolioService, PortfolioService>();

            services.AddControllers();
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
                // Configure production error handling here
                // app.UseExceptionHandler("/Home/Error");
                // app.UseHsts();
            }

            // Enable CORS with a policy that allows requests from http://localhost:4200
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            // Configure the path base here
            app.UsePathBase("/seccl");

            // Configure other middleware and routing here
            // ...

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
