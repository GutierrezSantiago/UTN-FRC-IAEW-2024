using APIEstudiantes.Models;
using APIEstudiantes.Repositories;
using Microsoft.AspNetCore.Builder;
namespace APIEstudiantes.Endpoints
{
    public static class EstudiantesEndpoints
    {
        public static void MapEstudiantesEndpoints(this IEndpointRouteBuilder routes)
        {
        routes.MapGet("/api/estudiantes", async (IEstudiantesRepository repo) =>
        {
            return Results.Ok(await
            repo.GetAllEstudiantes());
        }).RequireAuthorization("read:estudiantes");
        
        routes.MapGet("/api/estudiantes/{id}", async (IEstudiantesRepository repo, string id) =>
        {
            var estudiante = await
            repo.GetEstudianteById(id);
            return estudiante is not null ? Results.Ok(estudiante) : Results.NotFound();
        }).RequireAuthorization("read:estudiantes");
        
        routes.MapPost("/api/estudiantes", async (IEstudiantesRepository repo, Estudiante estudiante) =>
        {
            await repo.CreateEstudiante(estudiante);
            return Results.Created($"/api/estudiantes/{estudiante.Id}", estudiante);
        }).RequireAuthorization("write:estudiantes");
        
        routes.MapPut("/api/estudiantes/{id}", async (IEstudiantesRepository repo, string id, Estudiante estudiante) =>
        {
            var estudianteExistente = await
            repo.GetEstudianteById(id);
            if (estudianteExistente is null)
            {
                return Results.NotFound();
            }
            estudiante.Id = id;
            await repo.UpdateEstudiante(id, estudiante);
            return Results.NoContent();
        }).RequireAuthorization("write:estudiantes");
        
        routes.MapDelete("/api/estudiantes/{id}", async (IEstudiantesRepository repo, string id) =>
        {
            var estudiante = await
            repo.GetEstudianteById(id);
            if (estudiante is null)
            {
                return Results.NotFound();
            }
            await repo.DeleteEstudiante(id);
            return Results.NoContent();
        }).RequireAuthorization("write:estudiantes");
        }
    }
}