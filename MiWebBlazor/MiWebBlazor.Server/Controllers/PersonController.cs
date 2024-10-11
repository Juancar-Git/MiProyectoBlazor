using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Server.Data;
using MiWebBlazor.Shared;

namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPerson()
        {
            var lista = await _context.Persons.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{resumeId}")]
        public async Task<ActionResult<List<Person>>> GetSinglePerson(int resumeId)
        {
            var miobjeto = await _context.Persons.FirstOrDefaultAsync(ob => ob.ResumeId == resumeId);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Person>> CreatePerson(Person objeto)
        {

            _context.Persons.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbPerson());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person objeto)
        {

            var DbObjeto = await _context.Persons.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Person)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Persons.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var DbObjeto = await _context.Persons.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Persons.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPerson());
        }


        private async Task<List<Person>> GetDbPerson()
        {
            return await _context.Persons.ToListAsync();
        }
    }
}

