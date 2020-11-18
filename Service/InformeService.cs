using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;

namespace TutoFinder.Service
{
    public interface InformeService
    {
        Task<DataCollection<InformeDto>> GetAll(int page, int take);
        Task<InformeDto> GetById(int id);
        Task<InformeDto> Create(InformeCreateDto model);
        Task Update(int id, InformeUpdateDto model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
