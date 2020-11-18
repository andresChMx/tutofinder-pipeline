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
    [Route("pagos")]
    public class PagoController : ControllerBase
    {
        private readonly PagoService _PagoService;

        public PagoController(PagoService PagoService)
        {
            _PagoService = PagoService;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<PagoDto>>> GetAll(int page, int take)
        {
            return await _PagoService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PagoDto>> GetById(int id)
        {
            if (_PagoService.Existencia(id) == true)
            {
                return await _PagoService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(PagoCreateDto Pago)
        {
            var result = await _PagoService.Create(Pago);
            return CreatedAtAction(
                "GetById",
                new { id = result.PagoId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PagoUpdateDto model)
        {
            if (_PagoService.Existencia(id) == true)
            {
                await _PagoService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _PagoService.Remove(id);
            return NoContent();
        }
    }
}
