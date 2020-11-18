using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;

namespace TutoFinder.Service
{
    public interface PagoService
    {
        Task<DataCollection<PagoDto>> GetAll(int page, int take);
        Task<PagoDto> GetById(int id);
        Task<PagoDto> Create(PagoCreateDto model);
        Task Update(int id, PagoUpdateDto model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
