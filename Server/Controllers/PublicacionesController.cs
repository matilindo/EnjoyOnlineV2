using EnjoyOnline.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnjoyOnline.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController
    {
        private readonly AppDbContext _context;

        // GET: api/publicaciones/
        [HttpGet("archivos/{carpeta}")]
        public async Task<ActionResult<IEnumerable<string>>> GetArchivos(string carpeta)
        {
            List<string> lista = Shared.Models.Utilidades.archivoCarpeta(carpeta).ToList();

            return lista;
        }

        // GET: api/publicaciones/
        [HttpGet("archivos/{carpeta}/{subcarpeta}")]
        public async Task<ActionResult<IEnumerable<string>>> GetArchivosSubcarpeta(string carpeta, string subCarpeta)
        {
            List<string> lista = Shared.Models.Utilidades.archivoCarpetaSubcarpeta(carpeta, subCarpeta).ToList();

            return lista;
        }
    }
}
