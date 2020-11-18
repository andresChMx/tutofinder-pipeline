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
    [Route("docentes")]
    public class DocenteController : ControllerBase
    {
        private readonly DocenteService _DocenteService;

        public DocenteController(DocenteService DocenteService)
        {
            _DocenteService = DocenteService;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollection<DocenteDto>>> GetAll(int page, int take)
        {
            return await _DocenteService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocenteDtoPresentar>> GetById(int id)
        {
            if (_DocenteService.Existencia(id) == true)
            {
                return await _DocenteService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(DocenteCreateDto Docente)
        {
            var result = await _DocenteService.Create(Docente);
            return CreatedAtAction(
                "GetById",
                new { id = result.DocenteId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DocenteUpdateDto model)
        {
            if (_DocenteService.Existencia(id) == true)
            {
                await _DocenteService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _DocenteService.Remove(id);
            return NoContent();
        }
    }
}
