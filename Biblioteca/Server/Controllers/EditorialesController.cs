using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Server.Data;
using Biblioteca.Shared.Modelos;

namespace Biblioteca.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private readonly BDBibliotecaContext _context;

        public EditorialesController(BDBibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/Editoriales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorial>>> GetEditoriales()
        {
            if (_context.Editoriales == null)
            {
                return NotFound();
            }
            return await _context.Editoriales.ToListAsync();
        }

        // GET: api/Editoriales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editorial>> GetEditorial(int id)
        {
            if (_context.Editoriales == null)
            {
                return NotFound();
            }
            var editorial = await _context.Editoriales.FindAsync(id);

            if (editorial == null)
            {
                return NotFound();
            }

            return editorial;
        }

        // PUT: api/Editoriales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditorial(int id, Editorial editorial)
        {
            if (id != editorial.Id)
            {
                return BadRequest();
            }

            _context.Entry(editorial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorialExists(id))
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

        // POST: api/Editoriales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Editorial>> PostEditorial(Editorial editorial)
        {
            if (_context.Editoriales == null)
            {
                return Problem("Entity set 'BDBibliotecaContext.Editoriales'  is null.");
            }
            _context.Editoriales.Add(editorial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditorial", new { id = editorial.Id }, editorial);
        }

        // DELETE: api/Editoriales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditorial(int id)
        {
            if (_context.Editoriales == null)
            {
                return NotFound();
            }
            var editorial = await _context.Editoriales.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }

            _context.Editoriales.Remove(editorial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EditorialExists(int id)
        {
            return (_context.Editoriales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
