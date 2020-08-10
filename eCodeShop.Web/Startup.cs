using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using eShopCore.Infrastructure;
using System.Reflection;
using eCodeShop.Core.Interfaces;
using Microsoft.Net.Http.Headers;
using eShopCore.Infrastructure.Data;
using eCodeShop.Services.Interfaces;
using eCodeShop.Services.Services;

namespace eCodeShop.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("eCodeShop.Api")));
            //services.AddSwaggerGen(c =>
            //{

            //});
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ecode-shop-angular/dist";
            //});

            var jwtConfig = _configuration.GetSection("Jwt");
            var corsPolicyName = _configuration.GetValue<string>("CorsPolicyName");

            // Injections
            //services.AddScoped<DbContext, ECodeShopContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IRepository<>), typeof(ECodeShopRepository<>));

            // add it to the 'ConfigureServices' method of the Startup.cs
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidIssuer = jwtConfig.GetValue<string>("IssuerName"),
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.GetValue<string>("SecretKey")))
                    };
                });

            services.AddDbContext<ECodeShopContext>(options =>
                    options.UseSqlServer(_configuration.GetConnectionString("Default")));

            // add it to the 'ConfigureServices' method of the Startup.cs
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicyName,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.WithHeaders(HeaderNames.ContentType);
                        builder.WithMethods("PUT", "POST", "GET");
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var corsPolicyName = _configuration.GetValue<string>("CorsPolicyName");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(corsPolicyName);

            app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();
            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //// specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });


            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ecode-shop-angular";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});

        }
    }
}
