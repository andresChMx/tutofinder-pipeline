using Microsoft.AspNetCore.Mvc;
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
    [Route("tarjetas")]
    public class TarjetaController : ControllerBase
    {
        private readonly TarjetaService _TarjetaService;

        public TarjetaController(TarjetaService TarjetaService)
        {
            _TarjetaService = TarjetaService;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<TarjetaDto>>> GetAll(int page, int take)
        {
            return await _TarjetaService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarjetaDto>> GetById(int id)
        {
            if (_TarjetaService.Existencia(id) == true)
            {
                return await _TarjetaService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(TarjetaCreateDto Tarjeta)
        {
            var result = await _TarjetaService.Create(Tarjeta);
            return CreatedAtAction(
                "GetById",
                new { id = result.TarjetaId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TarjetaUpdateDto model)
        {
            if (_TarjetaService.Existencia(id) == true)
            {
                await _TarjetaService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _TarjetaService.Remove(id);
            return NoContent();
        }
    
    }
}
