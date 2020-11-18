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
    [Route("cursos")]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _CursoService;

        public CursoController(CursoService CursoService)
        {
            _CursoService = CursoService;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<CursoDto>>> GetAll(int page, int take)
        {
            return await _CursoService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDto>> GetById(int id)
        {
            if (_CursoService.Existencia(id) == true)
            {
                return await _CursoService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CursoCreateDto Curso)
        {
            var result = await _CursoService.Create(Curso);
            return CreatedAtAction(
                "GetById",
                new { id = result.CursoId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CursoUpdateDto model)
        {
            if (_CursoService.Existencia(id) == true)
            {
                await _CursoService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _CursoService.Remove(id);
            return NoContent();
           
        }
    }
}
