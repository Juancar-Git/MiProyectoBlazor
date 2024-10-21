using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Server.Data;
using MiWebBlazor.Shared;

namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public FactController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fact>>> GetFact()
        {
            var lista = await _context.Facts.ToListAsync();
            return Ok(lista);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Fact>>> GetSingleFact(int id)
        {
            var miobjeto = await _context.Facts.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Fact>> CreateFact(Fact objeto)
        {

            _context.Facts.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbFact());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Fact>>> UpdateFact(Fact objeto)
        {

            var DbObjeto = await _context.Facts.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Fact)objeto.Clone();

            await _context.SaveChangesAsync();

            return Ok(await _context.Facts.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Fact>>> DeleteFact(int id)
        {
            var DbObjeto = await _context.Facts.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Facts.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbFact());
        }


        private async Task<List<Fact>> GetDbFact()
        {
            return await _context.Facts.ToListAsync();
        }
    }
}