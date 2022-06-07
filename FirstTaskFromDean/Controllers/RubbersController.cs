using System.Collections;
using FirstTaskFromDean.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstTaskFromDean.Controllers;

[ApiController]
[Route("[controller]")]
public class RubbersController : Controller
{

    private static List<Rubber> Rubbers = new List<Rubber>()
    {
        new Rubber
        {
            id = Guid.NewGuid(),
            name = "T-Energy50",
            brand = "Butterfly",
            power = 89,
            speed = 91,
            spin = 89,
            touch = 70
        }   
    };

    private readonly ILogger<RubbersController> _logger;

    public RubbersController(ILogger<RubbersController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetRubbers")]
    public IActionResult GetRubbers()
    {
        // List<Rubber> rubbers = new List<Rubber>();
        // foreach (var VARIABLE in COLLECTION)
        // {
        //     
        // }
        return Ok(Rubbers);
    }

    [HttpGet("GetRubber/{id}")]
    public IActionResult GetRubber([FromRoute] Guid id)
    {
        foreach (Rubber rubber in Rubbers)
        {
            if (rubber.id == id)
            {
                return Ok(rubber);
            }
        }

        return BadRequest("ID does not exist");
    }

    [HttpPost("CreateRubber")]
    public async Task<IActionResult> CreateRubber([FromBody] Rubber newRubber)
    {
        Rubber rubber = new Rubber
        {
            brand = newRubber.brand,
            id = Guid.NewGuid(),
            name = newRubber.name,
            power = newRubber.power,
            speed = newRubber.speed,
            spin = newRubber.spin,
            touch = newRubber.touch
        };
        
        Rubbers.Add(rubber);
        return Ok(Rubbers);
    }

    [HttpPut("UpdateRubber/{id}")]
    public async Task<IActionResult> UpdateRubber([FromRoute] Guid id, [FromBody] Rubber updatedRubber)
    {
        foreach (Rubber rubber in Rubbers)
        {
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
        }

        return BadRequest("ID does not exist");
    }

    [HttpDelete("DeleteRubber/{id}")]
    public async Task<IActionResult> DeleteRubber([FromRoute] Guid id)
    {
        foreach (Rubber rubber in Rubbers)
        {
            if (rubber.id == id)
            {
                Rubbers.Remove(rubber);
                return Ok("Product removed");
            }
        }

        return BadRequest("ID does not exist");
    }
}

