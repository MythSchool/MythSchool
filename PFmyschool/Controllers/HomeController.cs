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


        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            var schools = await _context.Escuelas.Include(z => z.Ubicacion).Include(z => z.Sostenimiento).Include(z => z.Nivel).Include(z => z.Ubicacion.Localidad).ToListAsync();
            return View(schools);
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
      
        [HttpPost]
        public IActionResult Filtrar(int ubicacion, int nivel, int sostenimiento, int order, string ValorUbicacion, string ValorNivel, string ValorSostnimiento, int ValorOrder)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
               "Data Source=DESKTOP-2NBP7F1;" +
                 "Initial Catalog=MythSchoolDB;" +
                 "Integrated Security=True;";
                conn.Open();
                var p = new DynamicParameters();
                p.Add("@valorUbicacion", ValorUbicacion);
                p.Add("@valorNivel", ValorNivel);
                p.Add("@valorSostenimiento", ValorSostnimiento);
                p.Add("@valorOrder", ValorOrder);
                p.Add("@Ubicacion", ubicacion);
                p.Add("@Nivel", nivel);
                p.Add("@Sostenimiento", sostenimiento);
                p.Add("@Order", order);



                var escuela = conn.Execute("StpFiltrado", p, commandType: CommandType.StoredProcedure);

                conn.Close();
                return View(escuela);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error" + ex.Message);

            }
        }


        
       
    }
}
