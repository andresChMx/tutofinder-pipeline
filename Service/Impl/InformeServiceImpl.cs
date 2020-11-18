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
    public class InformeServiceImpl : InformeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InformeServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<InformeDto> Create(InformeCreateDto model)
        {
            var entry = new Informe
            {
                TutoriaId = model.TutoriaId,
                Descripcion =model.Descripcion,
                Fecha=model.Fecha

            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<InformeDto>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Informe
            {
                InformeId = id
            });
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, InformeUpdateDto model)
        {
            var entry = await _context.Informes.SingleAsync(x => x.InformeId == id);
            entry.TutoriaId = model.TutoriaId;
            entry.Descripcion = model.Descripcion;
            entry.Fecha = model.Fecha;
            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<InformeDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<InformeDto>>(
                await _context.Informes
                .Include(x=>x.Tutoria).ThenInclude(x=>x.Alumno).ThenInclude(x=>x.Padre)
                .Include(x => x.Tutoria).ThenInclude(x => x.Curso)
                .OrderByDescending(x => x.InformeId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<InformeDto> GetById(int id)
        {
            return _mapper.Map<InformeDto>(
                await _context.Informes.Include(x => x.Tutoria).ThenInclude(x => x.Alumno).ThenInclude(x => x.Padre)
                .Include(x => x.Tutoria).ThenInclude(x => x.Curso)
                .SingleAsync(x => x.InformeId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Informes.Where(x => x.InformeId == id).FirstOrDefault() == null)
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
