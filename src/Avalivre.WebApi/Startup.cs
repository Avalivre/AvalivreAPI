using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalivre.Application.ReviewServices;
using Avalivre.Application.ReviewServices.Impl;
using Avalivre.Application.UserServices;
using Avalivre.Application.UserServices.Impl;
using Avalivre.Domain.Products;
using Avalivre.Domain.Reviews;
using Avalivre.Domain.Users;
using Avalivre.Infrastructure.DTO.Configuration;
using Avalivre.Infrastructure.Persistence.Context;
using Avalivre.Infrastructure.Persistence.Repositories;
using Avalivre.Infrastructure.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Avalivre.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddDbContext<DataContext>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("SqlServerDB")));
            services.AddControllers();

            // IoC Container
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<UnitOfWork>();

            var secretKey = Configuration.GetSection("JwtConfig:SecretKey").Value;
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            ConfigureTokenValidation(services, securityKey);

            services.AddCors();
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

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Priv Methods
        private void ConfigureTokenValidation(IServiceCollection services, SecurityKey securityKey)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey
            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = _env.IsDevelopment();
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameters;
                });
        }
        #endregion
    }
}
