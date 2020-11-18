using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;
using TutoFinder.Entity;
using TutoFinder.Persistence;

namespace TutoFinder.Service.Impl
{
    public class CursoServiceImpl : CursoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CursoServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CursoDto> Create(CursoCreateDto model)
        {
            var entry = new Curso
            {
                Nombre = model.Nombre,
                Grado_academico = model.Grado_academico,
                Descripcion = model.Descripcion
                
            };
            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<CursoDto>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Curso
            {
                CursoId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, CursoUpdateDto model)
        {
            var entry = await _context.Cursos.SingleAsync(x => x.CursoId == id);
            entry.Nombre = model.Nombre;
            entry.Grado_academico = model.Grado_academico;
            entry.Descripcion = model.Descripcion;
            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<CursoDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<CursoDto>>(
                await _context.Cursos
                .OrderByDescending(x => x.CursoId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<CursoDto> GetById(int id)
        {
            return _mapper.Map<CursoDto>(
                await _context.Cursos.SingleAsync(x => x.CursoId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Cursos.Where(x => x.CursoId == id).FirstOrDefault() == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
