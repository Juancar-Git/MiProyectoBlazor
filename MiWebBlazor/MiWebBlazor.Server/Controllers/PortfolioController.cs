using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiWebBlazor.Server.Data;
using MiWebBlazor.Shared;
using Microsoft.EntityFrameworkCore;
 
namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public PortfolioController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Portfolio>>> GetPortfolio()
        {
            var lista = await _context.Portfolios.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Portfolio>>> GetSinglePortfolio(int id)
        {
            var miobjeto = await _context.Portfolios.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Portfolio>> CreatePortfolio(Portfolio objeto)
        {

            _context.Portfolios.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbPortfolio());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Portfolio>>> UpdatePortfolio(Portfolio objeto)
        {

            var DbObjeto = await _context.Portfolios.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Portfolio)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Portfolios.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Portfolio>>> DeletePortfolio(int id)
        {
            var DbObjeto = await _context.Portfolios.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Portfolios.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPortfolio());
        }


        private async Task<List<Portfolio>> GetDbPortfolio()
        {
            return await _context.Portfolios.ToListAsync();
        }
    }
}
