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
    public class LibrosController : ControllerBase
    {
        private readonly BDBibliotecaContext _context;

        public LibrosController(BDBibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            if (_context.Libros == null)
            {
                return NotFound();
            }
            return await _context.Libros.Include(e => e.Editorial).ToListAsync();
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            if (_context.Libros == null)
            {
                return NotFound();
            }
            var libro = await _context.Libros.Include(e => e.Editorial).Include(a=>a.Autores).FirstOrDefaultAsync(r => r.Id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            if (_context.Libros == null)
            {
                return Problem("Entity set 'BDBibliotecaContext.Libros'  is null.");
            }
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
        }

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("autores/{id}")]
        public async Task<ActionResult<Libro>> PostLibroAutores(int id, List<Autor> autores)
        {
            if (autores == null)
            {
                return Problem("La lista de autores es nula");
            }

            var ellibro = await _context.Libros.FindAsync(id);
            if (ellibro != null)
            {
                if (ellibro.Autores != null)
                {
                    ellibro.Autores.Clear();
                }
                ellibro.Autores = autores;
                await _context.SaveChangesAsync();

            }
            return CreatedAtAction("GetLibro", new { id = id }, ellibro);
        }


        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            if (_context.Libros == null)
            {
                return NotFound();
            }
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroExists(int id)
        {
            return (_context.Libros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
