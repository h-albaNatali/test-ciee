using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManager.Domain.Entities;
using ZooManager.Infrastructure.Data;
using ZooManager.Application.DTOs;
using Microsoft.AspNetCore.Authorization;


namespace ZooManager.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly ZooDbContext _context;
    private readonly IMapper _mapper;

    public AnimalsController(ZooDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAll()
    {
        var animals = await _context.Animals
            .Include(a => a.AnimalCares)
                .ThenInclude(ac => ac.Care)
            .ToListAsync();

        var result = _mapper.Map<List<AnimalDto>>(animals);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AnimalDto>> GetById(int id)
    {
        var animal = await _context.Animals
            .Include(a => a.AnimalCares)
                .ThenInclude(ac => ac.Care)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (animal == null) return NotFound();

        return Ok(_mapper.Map<AnimalDto>(animal));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAnimalDto dto)
    {
        var animal = _mapper.Map<Animal>(dto);
        _context.Animals.Add(animal);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = animal.Id }, _mapper.Map<AnimalDto>(animal));
    }

    [HttpDelete("{animalId}/cares/{careId}")]
    public async Task<IActionResult> RemoveCareFromAnimal(int animalId, int careId)
    {
        var animalCare = await _context.AnimalCares
            .FirstOrDefaultAsync(ac => ac.AnimalId == animalId && ac.CareId == careId);

        if (animalCare == null)
            return NotFound("Associação não encontrada.");

        _context.AnimalCares.Remove(animalCare);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAnimalDto dto)
    {
        if (id != dto.Id) return BadRequest("ID na URL difere do corpo da requisição.");

        var existingAnimal = await _context.Animals
            .Include(a => a.AnimalCares)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (existingAnimal == null) return NotFound();

        _context.AnimalCares.RemoveRange(existingAnimal.AnimalCares);

        _mapper.Map(dto, existingAnimal);

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var animal = await _context.Animals.FindAsync(id);
        if (animal == null) return NotFound();

        _context.Animals.Remove(animal);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("{animalId}/cares/{careId}")]
    public async Task<IActionResult> AddCareToAnimal(int animalId, int careId)
    {
        var animal = await _context.Animals.Include(a => a.AnimalCares)
                                        .FirstOrDefaultAsync(a => a.Id == animalId);
        var care = await _context.Cares.FindAsync(careId);

        if (animal == null || care == null)
            return NotFound("Animal ou cuidado não encontrado.");

        if (animal.AnimalCares.Any(ac => ac.CareId == careId))
            return BadRequest("Este cuidado já foi atribuído ao animal.");

        animal.AnimalCares.Add(new AnimalCare
        {
            AnimalId = animalId,
            CareId = careId
        });

        await _context.SaveChangesAsync();
        return NoContent();
    }

}
