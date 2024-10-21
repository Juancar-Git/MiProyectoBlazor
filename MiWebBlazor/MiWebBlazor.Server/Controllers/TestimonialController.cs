using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiWebBlazor.Server.Data;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebBlazor.Shared;
 
namespace MiWebBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public TestimonialController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Testimonial>>> GetTestimonial()
        {
            var lista = await _context.Testimonials.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Testimonial>>> GetSingleTestimonial(int id)
        {
            var miobjeto = await _context.Testimonials.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Testimonial>> CreateTestimonial(Testimonial objeto)
        {

            _context.Testimonials.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTestimonial());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Testimonial>>> UpdateTestimonial(Testimonial objeto)
        {

            var DbObjeto = await _context.Testimonials.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto = (Testimonial)objeto.Clone();


            await _context.SaveChangesAsync();

            return Ok(await _context.Testimonials.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Testimonial>>> DeleteTestimonial(int id)
        {
            var DbObjeto = await _context.Testimonials.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Testimonials.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbTestimonial());
        }


        private async Task<List<Testimonial>> GetDbTestimonial()
        {
            return await _context.Testimonials.ToListAsync();
        }
    }
}