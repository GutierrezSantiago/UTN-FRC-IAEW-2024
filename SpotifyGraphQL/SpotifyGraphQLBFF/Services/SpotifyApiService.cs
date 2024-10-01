using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.OAuth;
using SpotifyGraphQLBFF.Models;

namespace SpotifyGraphQLBFF.Services
{
    public class SpotifyApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string _accessToken;
        private DateTime _tokenExpiry;
        
        public SpotifyApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        private async Task AuthenticateAsync()
        {
            if(!string.IsNullOrEmpty(_accessToken) && _tokenExpiry > DateTime.UtcNow)
            {
                return;
            }

            var clientId = _configuration["Spotify:ClientId"];
            var clientSecret = _configuration["Spotify:ClientSecret"];

            var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"}
            });

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(); 
            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(content);
            
            _accessToken = tokenResponse.AccessToken;
            _tokenExpiry = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn);
            
            // Update authorization header with new access token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken); 
        }

        public async Task<string> SearchArtistsAsync(string query)
        {
            await AuthenticateAsync();

            var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type=artist");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // If needed, more methos to consume spotify api can be added here
    }
}