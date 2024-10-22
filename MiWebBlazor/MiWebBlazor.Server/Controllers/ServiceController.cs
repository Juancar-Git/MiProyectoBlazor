using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiWebBlazor.Server.Data;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Shared;

namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ServiceController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetService()
        {
            var lista = await _context.Services.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Service>>> GetSingleService(int id)
        {
            var miobjeto = await _context.Services.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Service>> CreateService(Service objeto)
        {

            _context.Services.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbService());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Service>>> UpdateService(Service objeto)
        {

            var DbObjeto = await _context.Services.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Service)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Services.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Service>>> DeleteService(int id)
        {
            var DbObjeto = await _context.Services.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Services.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbService());
        }


        private async Task<List<Service>> GetDbService()
        {
            return await _context.Services.ToListAsync();
        }
    }
}
