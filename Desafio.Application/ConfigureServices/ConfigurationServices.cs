using Desafio.Application.Interfaces;
using Desafio.Application.Services;
using Desafio.Application.Services.AccessToExternalServices;
using Desafio.Application.Services.HistoryFactories;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Interfaces.DomainHistoryInterfaces;
using Desafio.Domain.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Application.ConfigureServices
{
    public static class ConfigurationServices
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAcountService, AcountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGenerateSpotifyAccessTokenService, GenerateSpotifyAccessTokenService>();
            services.AddScoped<IRecommendedSpotifyPlaylistService, RecommendedSpotifyPlaylistService>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            services.AddScoped<IPersonalNotesServices, PersonalNoteService>();
            services.AddScoped<IValidateUserInfo, ValidateUserInfoService>();
            services.AddScoped<IValidatePersonalNotes, ValidatePersonalNotesService>();
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IEmailService, SendGridMailService>();
            services.AddScoped<IEntityHistoryFactory, EntityHistoryFactory>();
            services.AddAutoMapper(typeof(ConfigurationServices));
        }
    }
}
