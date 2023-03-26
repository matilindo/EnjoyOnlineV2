using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnjoyOnline.Server.Models;
using EnjoyOnline.Shared.Models;

namespace EnjoyOnline.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpleadoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Empleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> Getempleados()
        {
          if (_context.empleados == null)
          {
              return NotFound();
          }
            return await _context.empleados.ToListAsync();
        }

        // GET: api/EmpleadoesActivos
        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetempleadosActivos()
        {
            if (_context.empleados == null)
            {
                return NotFound();
            }
            return await _context.empleados.Where(e=>e.Estado.Contains("ACTIVO")).ToListAsync();
        }

        [HttpGet("noactivos")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetempleadosNoActivos()
        {
            if (_context.empleados == null)
            {
                return NotFound();
            }
            return await _context.empleados.Where(e => e.Estado != "ACTIVO").ToListAsync();
        }

        // GET: api/Empleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
          if (_context.empleados == null)
          {
              return NotFound();
          }
            var empleado = await _context.empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        //GET: api/Empleadoes/first
        [HttpGet("first")]
        public async Task<ActionResult<Empleado>> GetEmpleadoFirst()
        {
            if (_context.empleados == null)
            {
                return NotFound();
            }
            var empleado = await _context.empleados.FirstOrDefaultAsync(e=>e.Estado.Contains("ACTIVO"));

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // GET: api/Empleadoes/5
        [HttpGet("nombre/{nombre}")]
		public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleadosNombre(string nombre)
		{
			if (_context.empleados == null)
			{
				return NotFound();
			}
			var empleados = await _context.empleados.Where(empleado=>empleado.Nombre.Contains(nombre)).ToListAsync();
            

            if (empleados == null)
			{
				return NotFound();
			}

			return  empleados;
		}

      

        // GET: api/empleadoes/files
        [HttpGet("Files")]
        public async Task<ActionResult<IEnumerable<FileInfo>>> GetFiles()
        {
            var lista =await  Shared.Models.Utilidades.archivoCarpetaFiles();

            return lista.ToList();
        }

        // PUT: api/Empleadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.Nro_Funcionario)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
          if (_context.empleados == null)
          {
              return Problem("Entity set 'AppDbContext.empleados'  is null.");
          }
            _context.empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.Nro_Funcionario }, empleado);
        }

        // DELETE: api/Empleadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            if (_context.empleados == null)
            {
                return NotFound();
            }
            var empleado = await _context.empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return (_context.empleados?.Any(e => e.Nro_Funcionario == id)).GetValueOrDefault();
        }
    }
}
