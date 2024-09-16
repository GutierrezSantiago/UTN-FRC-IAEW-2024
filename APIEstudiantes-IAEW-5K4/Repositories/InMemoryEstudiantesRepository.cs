using APIEstudiantes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace APIEstudiantes.Repositories
{
public class InMemoryEstudiantesRepository :
IEstudiantesRepository
    {
        private readonly List<Estudiante> _estudiantes = new List<Estudiante>();
        public Task<IEnumerable<Estudiante>> GetAllEstudiantes()
        {
            return Task.FromResult<IEnumerable<Estudiante>>(_estudiantes);
        }
        public Task<Estudiante> GetEstudianteById(string id)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(estudiante);
        }
        public Task CreateEstudiante(Estudiante estudiante)
        {
            estudiante.Id = System.Guid.NewGuid().ToString();
            _estudiantes.Add(estudiante);
            return Task.CompletedTask;
        }
        public Task UpdateEstudiante(string id, Estudiante estudiante)
        {
            var index = _estudiantes.FindIndex(e => e.Id == id);
            if (index != -1)
        {
            _estudiantes[index] = estudiante;
            }
            return Task.CompletedTask;
        }

        public Task DeleteEstudiante(string id)
        {
        var estudiante = _estudiantes.FirstOrDefault(e => e.Id == id);
        if (estudiante != null)
        {
            _estudiantes.Remove(estudiante);
        }
        return Task.CompletedTask;
        }
    }
}