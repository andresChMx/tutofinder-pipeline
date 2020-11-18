using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;

namespace TutoFinder.Service
{
    public interface DocenteService
    {
        Task<DataCollection<DocenteDto>> GetAll(int page, int take);
        Task<DocenteDtoPresentar> GetById(int id);
        Task<DocenteDto> Create(DocenteCreateDto model);
        Task Update(int id, DocenteUpdateDto model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
