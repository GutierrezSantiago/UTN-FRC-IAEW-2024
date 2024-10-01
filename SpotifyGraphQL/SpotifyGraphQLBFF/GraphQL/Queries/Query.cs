using System.Text.Json;
using System.Text.Json.Serialization;
using HotChocolate;
using HotChocolate.Authorization;
using Microsoft.Extensions.Caching.Memory;
using SpotifyGraphQLBFF.Models;
using SpotifyGraphQLBFF.Services;

namespace SpotifyGraphQLBFF.GraphQL.Queries
{
    public class Query
    {
        [Authorize]
        public async Task<IEnumerable<Artist>> GetArtistsAsync(
            string name,
            [Service] SpotifyApiService spotifyApiService,
            [Service] IMemoryCache cache
        )
        {
            if (!cache.TryGetValue($"artists_{name}", out IEnumerable<Artist> artists))
            {
                var data = await spotifyApiService.SearchArtistsAsync(name);
                var spotifyResponse = JsonSerializer.Deserialize<SpotifyArtistResponse>(data);
                artists = spotifyResponse.Artists.Items;

                //Cache options config
                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                cache.Set($"artists_{name}", artists, cacheOptions);
            }

            return artists;
        }

        public class SpotifyArtistResponse
        {
            [JsonPropertyName("artists")]
            public ArtistContainer Artists { get; set; }
        }

        public class ArtistContainer
        {
            [JsonPropertyName("items")]
            public List<Artist> Items { get; set; }
        }
    }
}