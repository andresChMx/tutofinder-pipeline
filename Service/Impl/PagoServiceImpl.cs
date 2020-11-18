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
    public class PagoServiceImpl : PagoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PagoServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagoDto> Create(PagoCreateDto model)
        {
            var entry = new Pago
            {
                TarjetaId=model.TarjetaId,
                TutoriaId = model.TutoriaId,
                Descripcion = model.Descripcion,
                CvcTarjeta = model.CvcTarjeta

            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<PagoDto>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Pago
            {
                PagoId = id
            });
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, PagoUpdateDto model)
        {
            var entry = await _context.Pagos.SingleAsync(x => x.PagoId == id);
            entry.TarjetaId = model.TarjetaId;
            entry.TutoriaId = model.TutoriaId;
            entry.Descripcion = model.Descripcion;
            entry.CvcTarjeta = model.CvcTarjeta;
            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<PagoDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<PagoDto>>(
                await _context.Pagos
                .Include(x=>x.Tarjeta)
                .Include(x => x.Tutoria)
                .ThenInclude(x => x.Alumno)
                .Include(x => x.Tutoria)
                .ThenInclude(x => x.Curso)
                .Include(x => x.Tutoria)
                .ThenInclude(x => x.Docente)
                .OrderByDescending(x => x.PagoId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<PagoDto> GetById(int id)
        {
            return _mapper.Map<PagoDto>(
                await _context.Pagos.Include(x=>x.Tarjeta).Include(x=>x.Tutoria)
                .ThenInclude(x=>x.Alumno)
                .Include(x => x.Tutoria)
                .ThenInclude(x => x.Curso) 
                .Include(x => x.Tutoria)
                .ThenInclude(x => x.Docente)
                .SingleAsync(x => x.PagoId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Pagos.Where(x => x.PagoId == id).FirstOrDefault() == null)
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
