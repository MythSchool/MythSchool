using PFmyschool.Context;
using PFmyschool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using PFmyschool.Models.Reporte;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PFmyschool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2NBP7F1; initial catalog=MythSchoolDB; Integrated Security= True");
        public IActionResult Index()
        {
            ViewBag.EscuelasUbi = _context.Ubicacion.Select(p => new SelectListItem()
            {
                Text = p.NombreUbi,
                Value = p.PkUbicacion.ToString()
            });

            ViewBag.EscuelasNivel = _context.Nivel.Select(p => new SelectListItem()
            {
                Text = p.NomNivel,
                Value = p.PkNivel.ToString()
            });

            ViewBag.EscuelasSos = _context.Sostenimiento.Select(p => new SelectListItem()
            {
                Text = p.NomSostenimiento,
                Value = p.PkSostenimiento.ToString()
            });

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Menu(ReporteEscuela e)
        {
            try
            {
                var response = await connection.QueryAsync<ReporteEscuela>("pruebafil", new {e.FkUbicacion, e.FkNivel, e.FkSostenimiento }, commandType: CommandType.StoredProcedure);
                return View(response);
            }
            catch (Exception ex)
            {
                return NotFound();

            }
        }

        [HttpGet]

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Informacion(int? id)
        {
            int? PkEscuela = id;
            if (PkEscuela == null)
            {
                return NotFound();
            }

            var informacion = _context.OfertasEdu.Include(z => z.Escuelas).Include(z => z.Escuelas.Ubicacion).Include(z => z.Escuelas.Sostenimiento).Include(z => z.Escuelas.Nivel).Include(z => z.Escuelas.Ubicacion.Localidad).Where(x => x.Escuelas.PkEscuela == id).ToList();

            if (informacion == null)
            {
                return NotFound();
            }
            return View(informacion);
        }



        public IActionResult RegistrarEscuela()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      

        [HttpGet]
        public async Task<IActionResult> Filtrar(int PkUbicacion, int PkNivel, int PkSostenimiento)
        {
            try
            {
                var response = await connection.QueryAsync<ReporteEscuela>("pruebafil", new { PkUbicacion, PkNivel, PkSostenimiento}, commandType: CommandType.StoredProcedure);
                return View(response);
            }
            catch (Exception ex)
            {
                return NotFound();

            }
        }



        [HttpPost]
        public async Task<IActionResult> Buscar(OfertasEdu e)
        {
            try
            {
                var response = await connection.QueryAsync<OfertasEdu>("pruebafil", new { e.Escuelas.FkUbicacion, e.Escuelas.FkNivel, e.Escuelas.FkSostenimiento }, commandType: CommandType.StoredProcedure);
                return View(response);
            }
            catch (Exception ex)
            {
                return NotFound();

            }
        }



    }
}
