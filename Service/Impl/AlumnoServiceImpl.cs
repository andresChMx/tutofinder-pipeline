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
    public class AlumnoServiceImpl : AlumnoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AlumnoServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AlumnoDto> Create(AlumnoCreateDto model)
        {
            var entry = new Alumno
            {
                PadreId=model.PadreId,
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                DNI = model.DNI,
                Correo = model.Correo,
                Grado_academico = model.Grado_academico
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<AlumnoDto>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Alumno
            {
                AlumnoId = id
            });
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, AlumnoUpdateDto model)
        {
            var entry = _context.Alumnos.Single(x => x.AlumnoId == id);
            entry.PadreId = model.PadreId;
            entry.Nombres = model.Nombres;
            entry.Apellidos = model.Apellidos;
            entry.DNI = model.DNI;
            entry.Correo = model.Correo;
            entry.Grado_academico = model.Grado_academico;

            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<AlumnoDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<AlumnoDto>>(
                await _context.Alumnos
                .Include(x=>x.Padre)
                .OrderByDescending(x => x.AlumnoId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<AlumnoDto> GetById(int id)
        {
            return _mapper.Map<AlumnoDto>(
                await  _context.Alumnos.Include(x=>x.Padre).SingleAsync(x => x.AlumnoId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Alumnos.Where(x => x.AlumnoId == id).FirstOrDefault() == null)
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
