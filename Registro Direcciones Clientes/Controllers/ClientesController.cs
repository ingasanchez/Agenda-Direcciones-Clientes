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

        [HttpPost]
        public async Task<JsonResult> GuardarDireccion([FromBody] DireccionCliente dir)
        {
            bool respuesta = false;

            if (ModelState.IsValid)
            {
                _context.Add(dir);
                await _context.SaveChangesAsync();
                respuesta = true;
            }

            return Json(new { resultado = respuesta });

        }

        [HttpGet]
        public  IActionResult ObtenerClientes()
        {

            List<Cliente> clientes = null;

            if (ModelState.IsValid)
            {
                clientes = _context.Clientes.ToList();
               
            }
            return Json(new { data = clientes });

        }

        [HttpGet]
        public string detalleDireccion( decimal codCli )
        {

            List<DireccionCliente> listDir = null;
            string res = "";

            if (ModelState.IsValid)
            {
                listDir = _context.DireccionClientes.Where(s => s.Idcliente == codCli).ToList();
                foreach (DireccionCliente dir in listDir)
                {
                    
                    Sector sector = _context.Sectors.Where(s => s.Idsector == dir.Idsector).FirstOrDefault();
                    var idprov = sector.Idprovincia;
                    string provincia = _context.Provincia.Where(p => p.Idprovincia == idprov).FirstOrDefault().Descripcion;
                    string calle = dir.Calle;
                    string direccion = dir.Direccion;
                    

                    res += "<tr><td>" + provincia + "</td>" +
                            "<td> " + sector.Descripcion + " </td> " +
                            "<td>" + calle + "</td>" +
                            "<td>" + direccion + "</td>" +
                            "<td><button class='btn btn-outline-danger btn-sm ml-2' type='button' onclick='EliminarDir(" + dir.Iddircliente + ")'>Borrar</button></td></tr>";

                }


            }

            if (listDir.Count == 0)
            {
                res = "<tr><td></td>" +
                            "<td>No hay registros.</td>" +
                            "<td></td></tr>";
            }
            return res;

        }

        [HttpGet]
        public IActionResult ObtenerSectores(decimal id)
        {

            List<Sector> sectores = null;

            if (ModelState.IsValid)
            {
                sectores = _context.Sectors.Where(s => s.Idprovincia == id).ToList();

            }
            return Json(new { data = sectores });

        }

        public IActionResult ObtenerProvincias()
        {

            List<Provincia> provincia = null;

            if (ModelState.IsValid)
            {
                provincia = _context.Provincia.ToList();

            }
            return Json(new { data = provincia });

        }

    }
}
