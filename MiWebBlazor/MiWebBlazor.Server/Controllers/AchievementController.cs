using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Server.Data;
using MiWebBlazor.Shared;

namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public AchievementController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Achievement>>> GetAchievement()
        {
            var lista = await _context.Achievements.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Achievement>>> GetSingleAchievement(int id)
        {
            var miobjeto = await _context.Achievements.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Achievement>> CreateAchievement(Achievement objeto)
        {

            _context.Achievements.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbAchievement());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Achievement>>> UpdateAchievement(Achievement objeto)
        {

            Achievement DbObjeto = await _context.Achievements.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Achievement)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Achievements.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Achievement>>> DeleteAchievement(int id)
        {
            var DbObjeto = await _context.Achievements.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Achievements.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbAchievement());
        }


        private async Task<List<Achievement>> GetDbAchievement()
        {
            return await _context.Achievements.ToListAsync();
        }
    }
}

