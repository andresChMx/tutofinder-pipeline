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
    [Route("informes")]
    public class InformeController : ControllerBase
    {
        private readonly InformeService _InformeService;

        public InformeController(InformeService InformeService)
        {
            _InformeService = InformeService;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<InformeDto>>> GetAll(int page, int take)
        {
            return await _InformeService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InformeDto>> GetById(int id)
        {
            if (_InformeService.Existencia(id) == true)
            {
                return await _InformeService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(InformeCreateDto Informe)
        {
            var result = await _InformeService.Create(Informe);
            return CreatedAtAction(
                "GetById",
                new { id = result.InformeId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, InformeUpdateDto model)
        {
            if (_InformeService.Existencia(id) == true)
            {
                await _InformeService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _InformeService.Remove(id);
            return NoContent();
        }
    }
}
