using Desafio.Application.Interfaces;
using Desafio.Application.ResponseObject;
using Desafio.Domain.Validation;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Text;

namespace Desafio.Application.Services.AccessToExternalServices
{
    internal class GenerateSpotifyAccessTokenService : IGenerateSpotifyAccessTokenService
    {
        public SpotifyTokenResponse SpotifyTokenResponse { get; private set; }

        private readonly IConfiguration _configuration;
        public GenerateSpotifyAccessTokenService(IConfiguration configuration) => _configuration = configuration;

        public ValidationResponse GenerateToken()
        {
            var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(_configuration["Spotify:ClientID"] + ":" + _configuration["Spotify:ClientSecret"]));
            var client = new RestClient(_configuration["Spotify:UrlToken"]);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Basic {auth}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                SpotifyTokenResponse = new JsonDeserializer().Deserialize<SpotifyTokenResponse>(response);
                return new ValidationResponse
                {
                    Message = "your token was successfully generated!!",
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
