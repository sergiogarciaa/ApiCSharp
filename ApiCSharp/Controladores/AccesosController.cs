using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCSharp.Entidades;
using DAL;

namespace ApiCSharp.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesosController : ControllerBase
    {
        private readonly Contexto _context;

        public AccesosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Accesos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acceso>>> GetAccesos()
        {
          if (_context.Accesos == null)
          {
              return NotFound();
          }
            return await _context.Accesos.ToListAsync();
        }

        // GET: api/Accesos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acceso>> GetAcceso(long id)
        {
          if (_context.Accesos == null)
          {
              return NotFound();
          }
            var acceso = await _context.Accesos.FindAsync(id);

            if (acceso == null)
            {
                return NotFound();
            }

            return acceso;
        }

        // PUT: api/Accesos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcceso(long id, Acceso acceso)
        {
            if (id != acceso.id_acceso)
            {
                return BadRequest();
            }

            _context.Entry(acceso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccesoExists(id))
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

        // POST: api/Accesos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acceso>> PostAcceso(Acceso acceso)
        {
          if (_context.Accesos == null)
          {
              return Problem("Entity set 'Contexto.Accesos'  is null.");
          }
            _context.Accesos.Add(acceso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcceso", new { id = acceso.id_acceso }, acceso);
        }

        // DELETE: api/Accesos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcceso(long id)
        {
            if (_context.Accesos == null)
            {
                return NotFound();
            }
            var acceso = await _context.Accesos.FindAsync(id);
            if (acceso == null)
            {
                return NotFound();
            }

            _context.Accesos.Remove(acceso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccesoExists(long id)
        {
            return (_context.Accesos?.Any(e => e.id_acceso == id)).GetValueOrDefault();
        }
    }
}
