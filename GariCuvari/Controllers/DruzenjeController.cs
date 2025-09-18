using GariCuvari.Data;
using GariCuvari.Models;
using GariCuvari.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GariCuvari.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DruzenjeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DruzenjeController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DruzenjaDto>>> GetDruzenja()
        {
            var hangouts = await _context.Druzenja
                .Include(h => h.Garis)
                .Select(h => new DruzenjaDto
                {
                    Id = h.Id,
                    Title = h.Title,
                    Date = h.Date,
                    Location = h.Location,
                    Garis = h.Garis.Select(g => new GariDto
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Lastname = g.Lastname
                    }).ToList()
                }).ToListAsync();

            return hangouts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DruzenjaDto>> GetDruzenja(Guid id)
        {
            var hangout = await _context.Druzenja
                .Include(h => h.Garis)
                .Where(h => h.Id == id)
                .Select(h => new DruzenjaDto
                {
                    Id = h.Id,
                    Title = h.Title,
                    Date = h.Date,
                    Location = h.Location,
                    Garis = h.Garis.Select(g => new GariDto
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Lastname = g.Lastname
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (hangout == null)
                return NotFound();

            return hangout;
        }

        [HttpPost]
        public async Task<ActionResult<DruzenjaDto>> CreateHangout(DruzenjeCreateDto dto)
        {
            var garis = await _context.Garis
        .Where(g => dto.GariIds.Contains(g.Id))
        .ToListAsync();

            var hangout = new Druzenje
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Date = dto.Date,
                Location = dto.Location,
                Garis = garis
            };

            _context.Druzenja.Add(hangout);
            await _context.SaveChangesAsync();

            // Map to DruzenjaDto for returning to frontend
            var hangoutDto = new DruzenjaDto
            {
                Id = hangout.Id,
                Title = hangout.Title,
                Date = hangout.Date,
                Location = hangout.Location,
                Garis = hangout.Garis.Select(g => new GariDto
                {
                    Id = g.Id,
                    Name = g.Name ?? string.Empty,
                    Lastname = g.Lastname ?? string.Empty
                }).ToList()
            };

            return CreatedAtAction(nameof(GetDruzenja), new { id = hangout.Id }, hangoutDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHangout(Guid id, DruzenjeCreateDto dto)
        {
            var hangout = await _context.Druzenja
                .Include(h => h.Garis)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (hangout == null)
                return NotFound();

            // Update scalar properties
            hangout.Title = dto.Title;
            hangout.Date = dto.Date;
            hangout.Location = dto.Location;

            // Update related Garis (replace old list with new selection)
            var garis = await _context.Garis
                .Where(g => dto.GariIds.Contains(g.Id))
                .ToListAsync();
            hangout.Garis = garis;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHangout(Guid id)
        {
            var hangout = await _context.Druzenja.FindAsync(id);
            if (hangout == null)
                return NotFound();

            _context.Druzenja.Remove(hangout);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
