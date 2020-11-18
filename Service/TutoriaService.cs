using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;

namespace TutoFinder.Service
{
    public interface TutoriaService
    {
        Task<DataCollection<TutoriaDto>> GetAll(int page, int take);
        Task<TutoriaDto> GetById(int id);
        Task<TutoriaDto> Create(TutoriaCreateDto model);
        Task<DataCollection<TutoriaDto>> FiltroCurso(string curso, int page, int take);
        Task<DataCollection<TutoriaDto>> FiltroGradoAcademico(string grado, int page, int take);
        Task<DataCollection<TutoriaDto>> FiltroMembresia(bool membresia, int page, int take);
        Task<DataCollection<TutoriaDto>> FiltroCostoMaximo(double costo, int page, int take);
        Task Update(int id, TutoriaUpdateDto model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
