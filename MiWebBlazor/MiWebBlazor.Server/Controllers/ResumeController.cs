using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Server.Data;
using MiWebBlazor.Shared;

namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ResumeController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Resume>>> GetResume()
        {
            var lista = await _context.Resumes.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Resume>>> GetSingleResume(int id)
        {
            var miobjeto = await _context.Resumes.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Resume>> CreateResume(Resume objeto)
        {

            _context.Resumes.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbResume());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Resume>>> UpdateResume(Resume objeto)
        {

            var DbObjeto = await _context.Resumes.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Resume)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Resumes.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Resume>>> DeleteResume(int id)
        {
            var DbObjeto = await _context.Resumes.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Resumes.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbResume());
        }


        private async Task<List<Resume>> GetDbResume()
        {
            return await _context.Resumes.ToListAsync();
        }
    }
}

