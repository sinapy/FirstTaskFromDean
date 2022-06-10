using FirstTaskFromDean.Data;
using FirstTaskFromDean.Models;
using FirstTaskFromDean.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstTaskFromDean.Controllers;

[ApiController]
[Route("[controller]")]
public class RubbersController : Controller
{
    

    private IRubberRepository _repository;
    private readonly ILogger<RubbersController> _logger;
    private readonly FirstTaskDbContext _context;

    public RubbersController(
        ILogger<RubbersController> logger,
        FirstTaskDbContext context
        )
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("GetRubbers")]
    public IActionResult GetRubbers()
    {
        // List<Rubber> rubbers = new List<Rubber>();
        // foreach (var VARIABLE in COLLECTION)
        // {
        //     
        // }
        return Ok(_context.getRubbers());
    }

    [HttpGet("GetRubber/{id}")]
    public IActionResult GetRubber([FromRoute] Guid id)
    {
        foreach (var rubber in _context.getRubbers())
            if (rubber.id == id)
                return Ok(rubber);

        return BadRequest("ID does not exist");
    }

    [HttpPost("CreateRubber")]
    public async Task<IActionResult> CreateRubber([FromBody] Rubber newRubber)
    {
        var rubber = new Rubber
        {
            brand = newRubber.brand,
            id = Guid.NewGuid(),
            name = newRubber.name,
            power = newRubber.power,
            speed = newRubber.speed,
            spin = newRubber.spin,
            touch = newRubber.touch
        };

        _context.Add(rubber);
        return Ok(_context.getRubbers());
    }

    [HttpPut("UpdateRubber/{id}")]
    public async Task<IActionResult> UpdateRubber([FromRoute] Guid id, [FromBody] Rubber updatedRubber)
    {
        foreach (var rubber in _context.getRubbers())
            if (rubber.id == id)
            {
                rubber.brand = updatedRubber.brand;
                rubber.name = updatedRubber.name;
                rubber.power = updatedRubber.power;
                rubber.speed = updatedRubber.speed;
                rubber.spin = updatedRubber.spin;
                rubber.touch = updatedRubber.touch;
                return Ok("Product updated");
            }

        return BadRequest("ID does not exist");
    }

    [HttpDelete("DeleteRubber/{id}")]
    public async Task<IActionResult> DeleteRubber([FromRoute] Guid id)
    {
        foreach (var rubber in _context.getRubbers())
            if (rubber.id == id)
            {
                _context.Remove(rubber);
                return Ok("Product removed");
            }

        return BadRequest("ID does not exist");
    }
}

