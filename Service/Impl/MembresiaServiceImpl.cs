using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;
using TutoFinder.Entity;
using TutoFinder.Persistence;

namespace TutoFinder.Service.Impl
{
    public class MembresiaServiceImpl : MembresiaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MembresiaServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MembresiaDto> Create(MembresiaCreateDto model)
        {
            var entry = new Membresia
            {
                DocenteId=model.DocenteId,
                TarjetaId = model.TarjetaId,
                Cvc_tarjeta = model.Cvc_tarjeta,
                Fecha_expiracion = model.Fecha_expiracion
            };
            var entry2 = _context.Docentes.Single(x => x.DocenteId == model.DocenteId);
            entry2.Membresia = "Activa";

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<MembresiaDto>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Membresia
            {
                MembresiaId = id
            });
        
            await _context.SaveChangesAsync();
        }
        /*
        public void Desactivar(int id)
        {
            var entry = _context.Membresias.Single(x => x.MembresiaId == id);

            var entry2 = _context.Docentes.Single(x => x.DocenteId == entry.DocenteId);
            entry2.Status_Membresia = "Membresía desactivada";
            _context.SaveChanges();
        }
        */
        public async Task Update(int id, MembresiaUpdateDto model)
        {
            var entry = await _context.Membresias.SingleAsync(x => x.MembresiaId == id);
            entry.DocenteId = model.DocenteId;
            entry.TarjetaId = model.TarjetaId;
            entry.Cvc_tarjeta = model.Cvc_tarjeta;
            entry.Fecha_expiracion = model.Fecha_expiracion;
            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<MembresiaDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<MembresiaDto>>(
                await _context.Membresias
                .Include(x => x.Docente)
                .Include(x=>x.Tarjeta)
                .OrderByDescending(x => x.MembresiaId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<MembresiaDto> GetById(int id)
        {
            return _mapper.Map<MembresiaDto>(
                await _context.Membresias
                .Include(x => x.Docente)
                .Include(x => x.Tarjeta)
                .SingleAsync(x => x.MembresiaId == id));
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
