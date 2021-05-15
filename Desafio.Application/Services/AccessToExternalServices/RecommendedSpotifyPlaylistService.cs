using Desafio.Application.Interfaces;
using Desafio.Application.ResponseObject;
using SpotifyAPI.Web;
using System.Collections.Generic;

namespace Desafio.Application.Services.AccessToExternalServices
{
    internal class RecommendedSpotifyPlaylistService : IRecommendedSpotifyPlaylistService
    {

        private readonly IGenerateSpotifyAccessTokenService _generateSpotifyAccessToken;
        public RecommendedSpotifyPlaylistService(IGenerateSpotifyAccessTokenService generateSpotifyAccessToken) => _generateSpotifyAccessToken = generateSpotifyAccessToken;

        public RecommendedPlaylistResponse GetPlaylist(string category)
        {
            var result = _generateSpotifyAccessToken.GenerateToken();

            if (result.IsSuccess)
            {
                var recommendedPlaylist = new RecommendedPlaylistResponse();
                var spotify = new SpotifyClient(_generateSpotifyAccessToken.SpotifyTokenResponse.Access_Token);
                var playlists = spotify.Browse.GetCategoryPlaylists(category).Result;
                recommendedPlaylist.Playlist = new List<string>(playlists.Playlists.Items.Count);

                playlists.Playlists.Items.ForEach(x => recommendedPlaylist.Playlist.Add(x.Name));
                recommendedPlaylist.Message = "Your playlist was generated!";

                return recommendedPlaylist;
            }

            return (RecommendedPlaylistResponse)result;
        }
    }
}
