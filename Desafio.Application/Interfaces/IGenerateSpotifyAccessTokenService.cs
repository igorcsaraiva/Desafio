using Desafio.Application.ResponseObject;
using Desafio.Domain.Validation;

namespace Desafio.Application.Interfaces
{
    public interface IGenerateSpotifyAccessTokenService
    {
        SpotifyTokenResponse SpotifyTokenResponse { get; }
        ValidationResponse GenerateToken();
    }
}
