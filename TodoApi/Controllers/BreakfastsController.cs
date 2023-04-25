using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastsController : ControllerBase
    {
        private readonly MyWebAPIDBContext _context;

        public BreakfastsController(MyWebAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Breakfasts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breakfast>>> GetBreakfastFoods()
        {
          if (_context.BreakfastFoods == null)
          {
              return NotFound();
          }
            return await _context.BreakfastFoods.ToListAsync();
        }

        // GET: api/Breakfasts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breakfast>> GetBreakfast(int id)
        {
          if (_context.BreakfastFoods == null)
          {
              return NotFound();
          }
            var breakfast = await _context.BreakfastFoods.FindAsync(id);

            if (breakfast == null)
            {
                return NotFound();
            }

            return breakfast;
        }

        // PUT: api/Breakfasts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreakfast(int id, Breakfast breakfast)
        {
            if (id != breakfast.Id)
            {
                return BadRequest();
            }

            _context.Entry(breakfast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreakfastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Breakfasts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Breakfast>> PostBreakfast(Breakfast breakfast)
        {
          if (_context.BreakfastFoods == null)
          {
              return Problem("Entity set 'MyWebAPIDBContext.BreakfastFoods'  is null.");
          }
            _context.BreakfastFoods.Add(breakfast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreakfast", new { id = breakfast.Id }, breakfast);
        }

        // DELETE: api/Breakfasts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreakfast(int id)
        {
            if (_context.BreakfastFoods == null)
            {
                return NotFound();
            }
            var breakfast = await _context.BreakfastFoods.FindAsync(id);
            if (breakfast == null)
            {
                return NotFound();
            }

            _context.BreakfastFoods.Remove(breakfast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreakfastExists(int id)
        {
            return (_context.BreakfastFoods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
