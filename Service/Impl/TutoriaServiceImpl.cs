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
    public class TutoriaServiceImpl : TutoriaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TutoriaServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TutoriaDto> Create(TutoriaCreateDto model)
        {
            var entry = new Tutoria
            {
                AlumnoId = model.AlumnoId,
                CursoId = model.CursoId,
                DocenteId = model.DocenteId,
                Costo = model.Costo,
                Descripcion = model.Descripcion,
                Cantidad_minutos = model.Cantidad_minutos
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<TutoriaDto>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Tutoria
            {
                TutoriaId = id
            });
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, TutoriaUpdateDto model)
        {
            var entry = await _context.Tutorias.SingleAsync(x => x.TutoriaId == id);
            entry.AlumnoId = model.AlumnoId;
            entry.CursoId = model.CursoId;
            entry.DocenteId = model.DocenteId;
            entry.Costo = model.Costo;
            entry.Descripcion = model.Descripcion;
            entry.Cantidad_minutos = model.Cantidad_minutos;
            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<TutoriaDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<TutoriaDto>>(
                await _context.Tutorias
                .Include(x=>x.Alumno)
                .Include(x=>x.Curso)
                .Include(x=>x.Docente)
                .OrderByDescending(x => x.Docente.Membresia == "Activada")
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<DataCollection<TutoriaDto>> FiltroCurso(string curso, int page, int take)
        {
            return _mapper.Map<DataCollection<TutoriaDto>>(
                await _context.Tutorias
                .Include(x => x.Alumno)
                .Include(x => x.Curso)
                .Include(x => x.Docente)
                .Where(x => x.Curso.Nombre == curso)
                .OrderByDescending(x => x.TutoriaId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<DataCollection<TutoriaDto>> FiltroGradoAcademico(string grado, int page, int take)
        {
            return _mapper.Map<DataCollection<TutoriaDto>>(
                await _context.Tutorias
                .Include(x => x.Alumno)
                .Include(x => x.Curso)
                .Include(x => x.Docente)
                .Where(x => x.Curso.Grado_academico == grado)
                .OrderByDescending(x => x.TutoriaId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<DataCollection<TutoriaDto>> FiltroMembresia(bool membresia, int page, int take)
        {
            return _mapper.Map<DataCollection<TutoriaDto>>(
                await _context.Tutorias
                .Include(x => x.Alumno)
                .Include(x => x.Curso)
                .Include(x => x.Docente)
                .Where(x => x.Docente.Membresia == "Activada")
                .OrderByDescending(x => x.TutoriaId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<DataCollection<TutoriaDto>> FiltroCostoMaximo(double costo, int page, int take)
        {
            return _mapper.Map<DataCollection<TutoriaDto>>(
                await _context.Tutorias
                .Include(x => x.Alumno)
                .Include(x => x.Curso)
                .Include(x => x.Docente)
                .Where(x => x.Costo <= costo)
                .OrderByDescending(x => x.TutoriaId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<TutoriaDto> GetById(int id)
        {
            return _mapper.Map<TutoriaDto>(
                await _context.Tutorias
                .Include(x => x.Alumno)
                .Include(x => x.Curso)
                .Include(x => x.Docente)
                .SingleAsync(x => x.TutoriaId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Tutorias.Where(x => x.TutoriaId == id).FirstOrDefault() == null)
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
