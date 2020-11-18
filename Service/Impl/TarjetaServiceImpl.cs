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
    public class TarjetaServiceImpl : TarjetaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TarjetaServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TarjetaDto> Create(TarjetaCreateDto model)
        {
            var entry = new Tarjeta
            {
                Fecha_expiracion = model.Fecha_expiracion,
                Nombre_poseedor = model.Nombre_poseedor,
                Numero_tarjeta = model.Numero_tarjeta
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<TarjetaDto>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Tarjeta
            {
                TarjetaId = id
            });
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, TarjetaUpdateDto model)
        {
            var entry = await _context.Tarjetas.SingleAsync(x => x.TarjetaId == id);
            entry.Fecha_expiracion = model.Fecha_expiracion;
            entry.Nombre_poseedor = model.Nombre_poseedor;
            entry.Numero_tarjeta = model.Numero_tarjeta;
            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<TarjetaDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<TarjetaDto>>(
                await _context.Tarjetas
                .OrderByDescending(x => x.TarjetaId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<TarjetaDto> GetById(int id)
        {
            return _mapper.Map<TarjetaDto>(
                await _context.Tarjetas
                .SingleAsync(x => x.TarjetaId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Tarjetas.Where(x => x.TarjetaId == id).FirstOrDefault() == null)
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
