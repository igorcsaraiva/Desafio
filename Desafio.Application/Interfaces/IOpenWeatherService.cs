using Desafio.Application.ResponseObject;
using Desafio.Domain.Domain;
using Desafio.Domain.Validation;

namespace Desafio.Application.Interfaces
{
    public interface IOpenWeatherService
    {
        OpenWeatherResponse WeatherResponse { get; }
        ValidationResponse GetCurrentTemperatureHometown(UserInfo userInfo);
    }
}
