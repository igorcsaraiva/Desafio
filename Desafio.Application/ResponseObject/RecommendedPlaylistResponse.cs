using Desafio.Domain.Validation;
using System.Collections.Generic;

namespace Desafio.Application.ResponseObject
{
    public class RecommendedPlaylistResponse : ValidationResponse
    {
        public IList<string> Playlist { get; set; }
    }
}
