using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Registro_Direcciones_Clientes.Models;

namespace Registro_Direcciones_Clientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly TEST_ORIONTEKContext _context;

        public ClientesController(TEST_ORIONTEKContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Clientes.ToListAsync());
        }

        [HttpPost]
        public async Task<JsonResult> Guardar([FromBody] Cliente cliente)
        {
            bool respuesta = false;

            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                respuesta = true;
            }

            return Json(new { resultado = respuesta });
        
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {

            List<Cliente> clientes = null;

            if (ModelState.IsValid)
            {
                clientes = _context.Clientes.ToList();
               
            }
            return Json(new { data = clientes });

        }




    }
}
