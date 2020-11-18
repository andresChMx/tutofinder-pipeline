using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;
using TutoFinder.Service;

namespace TutoFinder.Controllers
{
    [ApiController]
    [Route("padres")]
    public class PadreController : ControllerBase
    {
        private readonly PadreService _PadreService;

        public PadreController(PadreService PadreService)
        {
            _PadreService = PadreService;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<PadreDto>>> GetAll(int page, int take)
        {
            return await _PadreService.GetAll(page, take);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PadreDto>> GetById(int id)
        {
            if (_PadreService.Existencia(id) == true)
            {
                return await _PadreService.GetById(id);
            }
            else
                return NotFound();

            //return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PadreCreateDto Padre)
        {
            var result = await _PadreService.Create(Padre);
            return CreatedAtAction(
                "GetById",
                new { id = result.PadreId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PadreUpdateDto model)
        {
            if (_PadreService.Existencia(id) == true)
            {
                await _PadreService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _PadreService.Remove(id);
            return NoContent();
        }
        [HttpGet]
        [Route("favoritos")]
        public async Task<ActionResult<DataCollection<FavoritoDto>>> GetAllFavoritos(int page, int take)
        {
            return await _PadreService.GetAllFavoritos(page, take);
        }
        [HttpPost]
        [Route("añadir-favoritos")]
        public async Task<ActionResult> Añadir(FavoritoDtoCreate model)
        {
            var result = await _PadreService.Añadir(model);
            return CreatedAtAction(
                "GetById",
                new { id = result.FavoritoId },
                result);
        }
        [HttpGet]
        [Route("favoritos/{id}")]
        public async Task<ActionResult<FavoritoDto>> GetFavorito(int id){
            return await _PadreService.GetFavorito(id);
        }

        [HttpGet]
        [Route("lista-favoritos/{id}")]
        public async Task<ActionResult<DataCollection<FavoritoDto>>> ListaFavorito(int page, int take, int id)
        {
            return await _PadreService.ListaFavorito(page, take, id);
        }
    }
}
