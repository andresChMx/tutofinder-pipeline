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
    public class PadreServiceImpl :PadreService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PadreServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PadreDto> Create(PadreCreateDto model)
        {
            var entry = new Padre
            {                
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                DNI=model.DNI,
                Correo = model.Correo
            };
            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
            return _mapper.Map<PadreDto>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Padre
            {
                PadreId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, PadreUpdateDto model)
        {
            var entry = await _context.Padres.SingleAsync(x => x.PadreId == id);
            entry.Nombres = model.Nombres;
            entry.Apellidos = model.Apellidos;
            entry.DNI = model.DNI;
            entry.Correo = model.Correo;
            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<PadreDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<PadreDto>>(
                await _context.Padres 
                .Include(x=>x.Alumnos)
                .OrderByDescending(x => x.PadreId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<PadreDto> GetById(int id)
        {
            return _mapper.Map<PadreDto>(await _context.Padres
               .SingleAsync(x => x.PadreId == id));
        }
        public async Task<DataCollection<FavoritoDto>> GetAllFavoritos(int page, int take)
        {
            return _mapper.Map<DataCollection<FavoritoDto>>(
                await _context.Favoritos
                .Include(x => x.Docente)
                .Include(x => x.Padre)
                .OrderByDescending(x => x.FavoritoId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<FavoritoDto> Añadir(FavoritoDtoCreate model)
        {
            var entry = new Favorito
            {
                PadreId = model.PadreId,
                DocenteId = model.DocenteId
            };
            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
            return _mapper.Map<FavoritoDto>(entry);
        }
        public async Task<FavoritoDto> GetFavorito(int id)
        {
            return _mapper.Map<FavoritoDto>(await _context.Favoritos.Include(x=>x.Padre)
                .Include(x=>x.Docente)
                .SingleAsync(x => x.FavoritoId == id));
        }
        public async Task<DataCollection<FavoritoDto>> ListaFavorito(int page, int take, int id)
        {
            return _mapper.Map<DataCollection<FavoritoDto>>(
               await _context.Favoritos
               .Include(x=>x.Docente)
               .Where(x=>x.PadreId == id)
               .OrderByDescending(x => x.PadreId)
               .AsQueryable()
               .PagedAsync(page, take));
        }
        public bool Existencia(int id)
        {
            if (_context.Padres.Where(x => x.PadreId == id).FirstOrDefault() == null)
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
