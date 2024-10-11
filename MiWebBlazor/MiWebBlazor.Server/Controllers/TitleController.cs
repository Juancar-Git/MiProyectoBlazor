using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Server.Data;
using MiWebBlazor.Shared;
using System.Collections.Generic;

namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public TitleController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Title>>> GetTitle()
        {
            var lista = await _context.Titles.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{resumeId}")]
        public async Task<ActionResult<List<Title>>> GetSingleTitle(int resumeId)
        {
            var miobjeto = await  _context.Titles.ToListAsync();
            List<Title> titleList = (List<Title>)miobjeto.Where(ob => ob.ResumeId == resumeId).ToList();
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(titleList);
        }
        [HttpPost]

        public async Task<ActionResult<Title>> CreateTitle(Title objeto)
        {

            _context.Titles.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTitle());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Title>>> UpdateTitle(Title objeto)
        {

            var DbObjeto = await _context.Titles.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Title)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Titles.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Title>>> DeleteTitle(int id)
        {
            var DbObjeto = await _context.Titles.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Titles.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbTitle());
        }


        private async Task<List<Title>> GetDbTitle()
        {
            return await _context.Titles.ToListAsync();
        }
    }
}

