using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebApiWithTokenAuth.Libraries;

namespace WebApiWithTokenAuth
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
               services.AddMvc(option => option.EnableEndpointRouting = false);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   //RequireExpirationTime=true,

                   ValidIssuer = "http://localhost:5001",
                   ValidAudience = "http://localhost:5001",
                   LifetimeValidator = TokenLifetimeValidator.Validate,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"))
               };
           });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        //builder.WithOrigins("http://example.com",
                        //                    "http://www.contoso.com");
                        builder.AllowAnyOrigin();
                    });

                //options.AddPolicy("AnotherPolicy",
                //    builder =>
                //    {
                //        builder.WithOrigins("http://www.contoso.com")
                //                            .AllowAnyHeader()
                //                            .AllowAnyMethod();
                //    });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();
            app.UseAuthentication();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
      
            app.UseMvc();
        }
    }
}
