using AutoMapper;
using Core.Entidades;
using GlobalTours.Dtos;

namespace GlobalTours.Helpers;

public class LugarUrlResolver : IValueResolver<Lugar,LugarDto, string>
{
    private readonly IConfiguration _config;

    public LugarUrlResolver(IConfiguration config)
    {
        _config = config;
    }
    public string Resolve(Lugar source, LugarDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ImagenUrl))
        {
            return _config["ApiUrl"] + source.ImagenUrl;
        }
        return null;
    }
}