using GariCuvari.Data;
using GariCuvari.Models;
using GariCuvari.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GariCuvari.Controllers
{
    //localhost:port/api/GariController
    [Route("api/[controller]")]
    [ApiController]
    public class GarisController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public GarisController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllGaris() {

            var allGaris = dbContext.Garis.ToList();
            return Ok(allGaris);
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetGariById(Guid id) {
            var gari = await dbContext.Garis.FindAsync(id);

            if(gari == null)
            {
                return NotFound(new { message = "Gari not found"});
            }

            return Ok(gari);
        }

        [HttpPost]
        public IActionResult AddGari(AddGariDto addGariDto)//Data transfer object
        {
            var GariEntity = new Gari()
            {
                //EntityFramework se brine o id-jevima, mi to ne dodajemo
                Name = addGariDto.Name,
                Lastname = addGariDto.Lastname,
                Description = addGariDto.Description,
                Closeness = addGariDto.Closeness,
                Priority = addGariDto.Priority,
            };

            dbContext.Garis.Add(GariEntity);
            dbContext.SaveChanges();
            //Ova linija je obavezna, inace se podaci ne bi sacuvali

            return Ok(GariEntity);
        }

        [HttpPut] //Update
        [Route("{id:guid}")]
        public IActionResult UpdateGari(Guid id, UpdateGariDto updateGariDto)
        {
            var gari = dbContext.Garis.Find(id);

            if (gari is null)
            {
                return NotFound();
            }

            gari.Name = updateGariDto.Name;
            gari.Lastname = updateGariDto.Lastname;
            gari.Priority = updateGariDto.Priority;
            gari.Description = updateGariDto.Description;
            gari.Closeness = updateGariDto.Closeness;

            dbContext.SaveChanges();

            return Ok(gari);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteGari(Guid id) {

            var gari = dbContext.Garis.Find(id);

            if(gari is null)
            {
                return NotFound();
            }

            dbContext.Garis.Remove(gari);
            dbContext.SaveChanges();
            return Ok(gari);

        }

    }
}
