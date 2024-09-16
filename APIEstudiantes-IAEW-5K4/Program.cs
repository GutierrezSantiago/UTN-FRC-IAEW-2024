using APIEstudiantes.Repositories;
using APIEstudiantes.Endpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
// Inyectar el repositorio en memoria
builder.Services.AddSingleton<IEstudiantesRepository,
InMemoryEstudiantesRepository>();
// Configuración de autenticación y autorización
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
options.Authority =
$"https://{builder.Configuration["Auth0:Domain"]}";
options.Audience =
builder.Configuration["Auth0:Audience"];
});
builder.Services.AddAuthorization(options =>
{
options.AddPolicy("read:estudiantes", policy =>
policy.RequireClaim("scope", "read:estudiantes"));
options.AddPolicy("write:estudiantes", policy =>
policy.RequireClaim("scope", "write:estudiantes"));
});
var app = builder.Build();
// Middleware de autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();
// Mapear las rutas de estudiantes
app.MapEstudiantesEndpoints();
app.Run();