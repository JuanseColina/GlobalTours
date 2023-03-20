using Core.Entidades;
using GlobalTours.Datos;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalTours.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LugaresController : Controller
{
    private readonly ApplicationDbContext _db; 

    public LugaresController(ApplicationDbContext db)
    {
        _db = db; // inyeccion de dependencias
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Lugar>>> GetLugares()
    {
        var lugares = await _db.Lugares.ToListAsync(); // se usa async para que no se bloquee el hilo

        return Ok(lugares);// se usa ok para que devuelva un 200
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Lugar>> GetLugar(int id)
    {
        return await _db.Lugares.FindAsync(id); // se usa async para que no se bloquee el hilo
    }
    
}