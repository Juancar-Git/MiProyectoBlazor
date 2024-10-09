using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Server.Data;
using MiWebBlazor.Shared;

namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetLocation()
        {
            var lista = await _context.Locations.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Location>>> GetSingleLocation(int id)
        {
            var miobjeto = await _context.Locations.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Location>> CreateLocation(Location objeto)
        {

            _context.Locations.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbLocation());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Location>>> UpdateLocation(Location objeto)
        {

            var DbObjeto = await _context.Locations.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Location)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Locations.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Location>>> DeleteLocation(int id)
        {
            var DbObjeto = await _context.Locations.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Locations.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbLocation());
        }


        private async Task<List<Location>> GetDbLocation()
        {
            return await _context.Locations.ToListAsync();
        }
    }
}

