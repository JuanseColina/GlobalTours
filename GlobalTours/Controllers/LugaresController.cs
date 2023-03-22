using AutoMapper;
using Core.Entidades;
using Core.Especificaciones;
using Core.Interfaces;
using GlobalTours.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTours.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LugaresController : Controller
{
    private readonly IRepositorio<Lugar> _lugarRepositorio;
    private readonly IRepositorio<Pais> _paisRepositorio;
    private readonly IRepositorio<Categoria> _categoriaRepositorio;
    private readonly IMapper _mapper;

    public LugaresController(IRepositorio<Lugar> lugarRepositorio, IRepositorio<Pais> paisRepositorio,
           IRepositorio<Categoria> categoriaRepositorio, IMapper mapper)
    {
        _lugarRepositorio = lugarRepositorio;
        _paisRepositorio = paisRepositorio;
        _categoriaRepositorio = categoriaRepositorio;
        _mapper = mapper;
    }
    
    [HttpGet]// se usa get para obtener los lugares
    public async Task<ActionResult<IReadOnlyList<LugarDto>>> GetLugares()
    {
        var espec = new LugaresConPaisCategoriaEspecificacion(); // se usa la especificacion
        var lugares = await _lugarRepositorio.ObtenerTodosEspec(espec); // se usa async para que no se bloquee el hilo

        return Ok(_mapper.Map<IReadOnlyList<Lugar>, IReadOnlyList<LugarDto>>(lugares));// se usa ok para que devuelva un 200
    }
    
    [HttpGet("{id}")]// se usa el id para buscar el lugar
    public async Task<ActionResult<LugarDto>> GetLugar(int id)
    {
        var espec = new LugaresConPaisCategoriaEspecificacion(id);// se usa la especificacion
        var lugar = await _lugarRepositorio.ObtenerEspec(espec); // se usa async para que no se bloquee el hilo
        return _mapper.Map<Lugar, LugarDto>(lugar); // se usa el mapper para mapear el lugar a un lugarDto
    }

    [HttpGet("paises")]
    public async Task<ActionResult<List<Pais>>> GetPaises()
    {
        return Ok(await _paisRepositorio.ObtenerTodosAsync());
    }
    
    [HttpGet("categorias")]
    public async Task<ActionResult<List<Categoria>>> GetCategoria()
    {
        return Ok(await _categoriaRepositorio.ObtenerTodosAsync());
    }

}