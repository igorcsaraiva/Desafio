using Desafio.Application.ResponseObject;

namespace Desafio.Application.Interfaces
{
    internal interface IRecommendedSpotifyPlaylistService
    {
        RecommendedPlaylistResponse GetPlaylist(string category);
    }
}
