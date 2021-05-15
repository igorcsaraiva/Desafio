

using Desafio.Domain.Interfaces;
using Desafio.Domain.Interfaces.DomainHistoryInterfaces;
using Desafio.Infra.Data;
using Desafio.Infra.Repository;
using Desafio.Infra.Repository.DomainHistoryRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Desafio.Infra.ConfigureServices
{
    public static class ConfigurationServices
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionContainer = configuration["DBSTRING"] ?? configuration.GetConnectionString("DefaultConnection");
            var connectionContainerHistory = configuration["DBSTRINGHISTORY"] ?? configuration.GetConnectionString("DefaultConnectionHistory");
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionContainer));
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionContainer));
            services.AddDbContext<HistoryContext>(options => options.UseSqlServer(connectionContainerHistory));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<IdentityContext>()
             .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["TokenValidationParameters:ValidAudience"],
                    ValidateIssuer = true,
                    ValidIssuer = configuration["TokenValidationParameters:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Secret:Key"])),
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IPersonalNotesRepository, PersonalNotesRepository>();
            services.AddScoped<IUserInfoHistoryRepository, UserInfoHistoryRepository>();
            services.AddScoped<IAcountHistoryRepository, AcountHistoryRepository>();
            services.AddScoped<IPersonalNotesHistoryRepository, PersonalNotesHistoryRepository>();
        }
    }
}
