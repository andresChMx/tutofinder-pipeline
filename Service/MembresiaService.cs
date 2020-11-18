using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;

namespace TutoFinder.Service
{
    public interface MembresiaService
    {
        Task<DataCollection<MembresiaDto>> GetAll(int page, int take);
        Task<MembresiaDto> GetById(int id);
        Task<MembresiaDto> Create(MembresiaCreateDto model);
        Task Update(int id, MembresiaUpdateDto model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
