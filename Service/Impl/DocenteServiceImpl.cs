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
    public class DocenteServiceImpl : DocenteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DocenteServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DocenteDto> Create(DocenteCreateDto model)
        {
            var entry = new Docente
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                DNI = model.DNI,
                Domicilio = model.Domicilio,
                Correo = model.Correo,
                Disponibilidad = model.Disponibilidad,
                Numero_cuenta = model.Numero_cuenta,
                Membresia = model.Membresia

            };

            

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<DocenteDto>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Docente
            {
                DocenteId = id
            });
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, DocenteUpdateDto model)
        {
            var entry = await _context.Docentes.SingleAsync(x => x.DocenteId == id);
            entry.Nombres = model.Nombres;
            entry.Apellidos = model.Apellidos;
            entry.DNI = model.DNI;
            entry.Domicilio = model.Domicilio;
            entry.Correo = model.Correo;
            entry.Disponibilidad = model.Disponibilidad;
            entry.Numero_cuenta = model.Numero_cuenta;
            entry.Membresia = model.Membresia;
            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<DocenteDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<DocenteDto>>(
                await _context.Docentes
                .OrderByDescending(x => x.DocenteId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<DocenteDtoPresentar> GetById(int id)
        {
            return _mapper.Map<DocenteDtoPresentar>(
                await _context.Docentes.SingleAsync(x => x.DocenteId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Docentes.Where(x => x.DocenteId == id).FirstOrDefault() == null)
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
