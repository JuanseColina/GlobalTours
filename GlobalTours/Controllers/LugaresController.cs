using Core.Entidades;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalTours.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LugaresController : Controller
{
    private readonly ILugarRepositorio _repo;
    public LugaresController(ILugarRepositorio repo)
    {
        _repo = repo;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Lugar>>> GetLugares()
    {
        var lugares = await _repo.GetLugaresAsync(); // se usa async para que no se bloquee el hilo

        return Ok(lugares);// se usa ok para que devuelva un 200
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Lugar>> GetLugar(int id)
    {
        return await _repo.GetLugarAsync(id); // se usa async para que no se bloquee el hilo
    }
    
}