using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;

namespace TutoFinder.Service
{
    public interface TarjetaService
    {
        Task<DataCollection<TarjetaDto>> GetAll(int page, int take);
        Task<TarjetaDto> GetById(int id);
        Task<TarjetaDto> Create(TarjetaCreateDto model);
        Task Update(int id, TarjetaUpdateDto model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
