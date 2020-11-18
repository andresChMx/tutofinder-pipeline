using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Commons;
using TutoFinder.Dto;
using TutoFinder.Entity;
using TutoFinder.Entity.Identity;

namespace TutoFinder.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Alumno, AlumnoDto>();
            CreateMap<DataCollection<Alumno>,DataCollection<AlumnoDto>>();

            CreateMap<Alumno, AlumnoDtoPresentar>();
            CreateMap<DataCollection<Alumno>, DataCollection<AlumnoDtoPresentar>>();

            CreateMap<Curso, CursoDto>();
            CreateMap<DataCollection<Curso>, DataCollection<CursoDto>>();

            CreateMap<Curso, CursoDtoPresentar>();
            CreateMap<DataCollection<Curso>, DataCollection<CursoDtoPresentar>>();

            CreateMap<Docente, DocenteDto>();
            CreateMap<DataCollection<Docente>, DataCollection<DocenteDto>>();

            CreateMap<Docente, DocenteDtoPresentar>();
            CreateMap<DataCollection<Docente>, DataCollection<DocenteDtoPresentar>>();

            CreateMap<Informe, InformeDto>();
            CreateMap<DataCollection<Informe>, DataCollection<InformeDto>>();           

            CreateMap<Padre, PadreDto>();
            CreateMap<DataCollection<Padre>, DataCollection<PadreDto>>();

            CreateMap<Padre, PadreDtoPresentar>();
            CreateMap<DataCollection<Padre>, DataCollection<PadreDtoPresentar>>();

            CreateMap<Favorito, FavoritoDto>();
            CreateMap<DataCollection<Favorito>, DataCollection<FavoritoDto>>();

            CreateMap<Pago, PagoDto>();
            CreateMap<DataCollection<Pago>, DataCollection<PagoDto>>();

            CreateMap<Pago, PagoDtoPresentar>();
            CreateMap<DataCollection<Pago>, DataCollection<PagoDtoPresentar>>();

            CreateMap<Tarjeta, TarjetaDto>();
            CreateMap<DataCollection<Tarjeta>, DataCollection<TarjetaDto>>();

            CreateMap<Tarjeta, TarjetaDtoPresentar>();
            CreateMap<DataCollection<Tarjeta>, DataCollection<TarjetaDtoPresentar>>();

            CreateMap<Tutoria, TutoriaDto>();
            CreateMap<DataCollection<Tutoria>, DataCollection<TutoriaDto>>();

            CreateMap<Membresia, MembresiaDto>();
            CreateMap<DataCollection<Membresia>, DataCollection<MembresiaDto>>();

            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(
                    dest => dest.NombreCompleto,
                    opts => opts.MapFrom(src => src.Apellidos + ", " + src.Nombres)
                ).ForMember(
                    dest => dest.Roles,
                    opts => opts.MapFrom(src => src.UserRoles.Select(y => y.Role.Name).ToList())
                );
            CreateMap<DataCollection<ApplicationUser>, DataCollection<ApplicationUserDto>>();
        }
    }
}
