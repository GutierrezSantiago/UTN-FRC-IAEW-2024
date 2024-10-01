using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SpotifyGraphQLBFF.GraphQL.Queries;
using SpotifyGraphQLBFF.GraphQL.Types;
using SpotifyGraphQLBFF.Services;

var builder = WebApplication.CreateBuilder(args);

// Services config
builder.Services.AddHttpClient<SpotifyApiService>(); // HttpClient registration for SpotifyApiService
builder.Services.AddMemoryCache(); // InMemory Cache Service
builder.Services.AddSingleton<SpotifyApiService>(); // SpotifyApiService service registration

// GraphQL config
builder.Services
    .AddGraphQLServer()
    .AddAuthorization() // Enables authorization in GraphQL
    .AddQueryType<Query>() // Main query type registration
    .AddType<ArtistType>() // ArtistType type registration
    .AddType<ImageType>(); // ImageType type registration

// Authentication and Authorization with Auth0
builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Defines default auth scheme
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Defines default challenge scheme
})
.AddJwtBearer(options => 
{
    options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/"; // Defines Auth0 authority
    options.Audience = builder.Configuration["Auth0:Audience"]; // Define audience (API identifier)
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true, // Validate token audience
        ValidAudience = builder.Configuration["Auth0:Audience"], // Valid audience
        ValidateIssuer = true, // Validate token issuer
        ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}/" // Valid issuer

    };
});

builder.Services.AddAuthorization(); 

var app = builder.Build();

// Middleware config
app.UseAuthentication(); // Enables authentication middleware
app.UseAuthorization(); // Enables authorization middleware

app.MapGraphQL(); // Maps GraphQL routes

app.Run();
