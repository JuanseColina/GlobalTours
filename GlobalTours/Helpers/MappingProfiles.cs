using AutoMapper;
using Core.Entidades;
using GlobalTours.Dtos;

namespace GlobalTours.Helpers;

public class MappingProfiles : Profile
{
    // AutoMapper se encarga de mapear los datos de la base de datos a los DTOs
    public MappingProfiles()
    {
        CreateMap<Lugar, LugarDto>()
            .ForMember(d => d.Pais, o => o.MapFrom(s => s.Pais.Nombre))
            .ForMember(d => d.Categoria, o => o.MapFrom(s => s.Categoria.Nombre))
            .ForMember(d => d.ImagenUrl, o => o.MapFrom<LugarUrlResolver>());
    }
}