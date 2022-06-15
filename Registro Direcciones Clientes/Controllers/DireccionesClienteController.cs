using Microsoft.AspNetCore.Mvc;
using Registro_Direcciones_Clientes.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Direcciones_Clientes.Controllers
{
    public class DireccionesClienteController : Controller
    {
        private readonly TEST_ORIONTEKContext _context;

        public DireccionesClienteController(TEST_ORIONTEKContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<JsonResult> BorrarDireccion( decimal id)
        {
            bool respuesta = false;

            if (ModelState.IsValid)
            {
                var direccion = _context.DireccionClientes.Where(d => d.Iddircliente == id).FirstOrDefault();
                _context.Remove(direccion);
                await _context.SaveChangesAsync();
                respuesta = true;

            }
            return Json(new { data = respuesta});

        }


    }
}
