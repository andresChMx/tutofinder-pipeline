using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;

namespace TutoFinder.Service
{
    public interface AlumnoService
    {
        Task<DataCollection<AlumnoDto>> GetAll(int page, int take);
        Task<AlumnoDto> GetById(int id);
        Task<AlumnoDto> Create(AlumnoCreateDto model);
        Task Update(int id, AlumnoUpdateDto model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
