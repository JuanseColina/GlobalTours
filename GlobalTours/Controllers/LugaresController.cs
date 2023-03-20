using Microsoft.AspNetCore.Mvc;

namespace GlobalTours.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LugaresController : Controller
{
    [HttpGet]
    public string GetLugares()
    {
        return "Esta va  a ser una lista de los lugares";
    }
    
    [HttpGet("{id}")]
    public string GetLugar(int id)
    {
        return "Este va a ser un lugar en particular";
    }
    
}