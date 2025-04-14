using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManager.Domain.Entities;
using ZooManager.Infrastructure.Data;
using ZooManager.Application.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;


namespace ZooManager.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CaresController : ControllerBase
{
    private readonly ZooDbContext _context;
    private readonly IMapper _mapper;

    public CaresController(ZooDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CareDto>>> GetAll()
    {
        var cares = await _context.Cares.ToListAsync();
        return Ok(_mapper.Map<List<CareDto>>(cares));
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Care>> GetById(int id)
    {
        var care = await _context.Cares
            .Include(c => c.AnimalCares)
            .ThenInclude(ac => ac.Animal)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (care == null) return NotFound();

        return care;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCareDto dto)
    {
        var care = _mapper.Map<Care>(dto);
        _context.Cares.Add(care);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = care.Id }, care);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Care care)
    {
        if (id != care.Id) return BadRequest();

        _context.Entry(care).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}/hard")]
    public async Task<IActionResult> HardDelete(int id)
    {
        var care = await _context.Cares
            .Include(c => c.AnimalCares)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (care == null) return NotFound();

        _context.AnimalCares.RemoveRange(care.AnimalCares);
        _context.Cares.Remove(care);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var care = await _context.Cares
            .Include(c => c.AnimalCares)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (care == null) return NotFound();

        _context.AnimalCares.RemoveRange(care.AnimalCares);
        _context.Cares.Remove(care);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
