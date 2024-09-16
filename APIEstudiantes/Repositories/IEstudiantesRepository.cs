using APIEstudiantes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace APIEstudiantes.Repositories
{
public interface IEstudiantesRepository
    {
        Task<IEnumerable<Estudiante>> GetAllEstudiantes();
        Task<Estudiante> GetEstudianteById(string id);
        Task CreateEstudiante(Estudiante estudiante);
        Task UpdateEstudiante(string id, Estudiante estudiante);
        Task DeleteEstudiante(string id);
    }
}