using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;

namespace TutoFinder.Service
{
    public interface PadreService
    {
        Task<DataCollection<PadreDto>> GetAll(int page, int take);
        Task<PadreDto> GetById(int id);
        Task<PadreDto> Create(PadreCreateDto model);
        Task Update(int id, PadreUpdateDto model);
        Task Remove(int id);
        bool Existencia(int id);
        Task<DataCollection<FavoritoDto>> GetAllFavoritos(int page, int take);
        Task<FavoritoDto> Añadir(FavoritoDtoCreate model);
        Task<FavoritoDto> GetFavorito(int id);
        Task<DataCollection<FavoritoDto>> ListaFavorito(int page, int take, int id);
    }
}
