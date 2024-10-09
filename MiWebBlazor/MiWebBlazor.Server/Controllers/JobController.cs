using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Server.Data;
using MiWebBlazor.Shared;

namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Job>>> GetJob()
        {
            var lista = await _context.Jobs.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Job>>> GetSingleJob(int id)
        {
            var miobjeto = await _context.Jobs.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Job>> CreateJob(Job objeto)
        {

            _context.Jobs.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbJob());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Job>>> UpdateJob(Job objeto)
        {

            var DbObjeto = await _context.Jobs.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Job)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Jobs.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Job>>> DeleteJob(int id)
        {
            var DbObjeto = await _context.Jobs.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Jobs.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbJob());
        }


        private async Task<List<Job>> GetDbJob()
        {
            return await _context.Jobs.ToListAsync();
        }
    }
}

