using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Server.Data;
using MiWebBlazor.Shared;

namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public SkillController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Skill>>> GetSkill()
        {
            var lista = await _context.Skills.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Skill>>> GetSingleSkill(int id)
        {
            var miobjeto = await _context.Skills.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Skill>> CreateSkill(Skill objeto)
        {

            _context.Skills.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbSkill());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Skill>>> UpdateSkill(Skill objeto)
        {

            var DbObjeto = await _context.Skills.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Skill)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Skills.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Skill>>> DeleteSkill(int id)
        {
            var DbObjeto = await _context.Skills.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Skills.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbSkill());
        }


        private async Task<List<Skill>> GetDbSkill()
        {
            return await _context.Skills.ToListAsync();
        }
    }
}

