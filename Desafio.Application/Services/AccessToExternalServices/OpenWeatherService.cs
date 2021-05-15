using Desafio.Application.Interfaces;
using Desafio.Application.ResponseObject;
using Desafio.Domain.Domain;
using Desafio.Domain.Validation;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serialization.Json;
using System;

namespace Desafio.Application.Services.AccessToExternalServices
{
    internal class OpenWeatherService : IOpenWeatherService
    {
        private readonly IConfiguration _configuration;
        public OpenWeatherResponse WeatherResponse { get; private set; }

        public OpenWeatherService(IConfiguration configuration) => _configuration = configuration;

        public ValidationResponse GetCurrentTemperatureHometown(UserInfo userInfo)
        {
            var client = new RestClient(new Uri(_configuration["OpenWeatherService:Url"] + "q=" + userInfo.HomeTown + "&appid=" + _configuration["OpenWeatherService:ApiKey"]));
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                WeatherResponse = new JsonDeserializer().Deserialize<OpenWeatherResponse>(response);

                return new ValidationResponse
                {
                    Message = "your request was successful!!",
                };
            }

            return new ValidationResponse
            {
                Message = "One or more validation errors occurred.",
                Erros = new string[1] { response.Content }
            };
        }
    }
}
