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
    [Route("alumnos")]
    public class AlumnoController : ControllerBase
    {
        private readonly AlumnoService _AlumnoService;

        public AlumnoController(AlumnoService alumnoService)
        {
            _AlumnoService = alumnoService;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<AlumnoDto>>> GetAll(int page, int take)
        {
            return await _AlumnoService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoDto>> GetById(int id)
        {
            
            if (_AlumnoService.Existencia(id) == true)
            {
                return await _AlumnoService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(AlumnoCreateDto Alumno)
        {
            var result = await _AlumnoService.Create(Alumno);
            return CreatedAtAction(
                "GetById",
                new { id = result.AlumnoId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AlumnoUpdateDto model)
        {
            if (_AlumnoService.Existencia(id) == true)
            {
                await _AlumnoService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            
            await _AlumnoService.Remove(id);
            return NoContent();
            
           
        }

    }
}
