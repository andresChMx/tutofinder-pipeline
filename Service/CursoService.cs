using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;

namespace TutoFinder.Service
{
    public interface CursoService
    {
        Task<DataCollection<CursoDto>> GetAll(int page, int take);
        Task<CursoDto> GetById(int id);
        Task<CursoDto> Create(CursoCreateDto model);
        Task Update(int id, CursoUpdateDto model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
