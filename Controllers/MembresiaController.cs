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
    [Route("membresias")]
    public class MembresiaController : ControllerBase
    {
        private readonly MembresiaService _MembresiaService;
        private readonly DocenteService _DocenteService;

        public MembresiaController(MembresiaService MembresiaService, DocenteService DocenteService)
        {
            _MembresiaService = MembresiaService;
            _DocenteService = DocenteService;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<MembresiaDto>>> GetAll(int page, int take)
        {
            return await _MembresiaService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MembresiaDto>> GetById(int id)
        {
            if (_MembresiaService.Existencia(id) == true)
            {
                return await _MembresiaService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(MembresiaCreateDto Membresia)
        {
            var result = await _MembresiaService.Create(Membresia);
            return CreatedAtAction(
                "GetById",
                new { id = result.MembresiaId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MembresiaUpdateDto model)
        {
            if (_MembresiaService.Existencia(id) == true)
            {
                await _MembresiaService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _MembresiaService.Remove(id);
            return NoContent();
        }
    }
}
