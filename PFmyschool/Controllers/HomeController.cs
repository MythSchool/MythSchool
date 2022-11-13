﻿using PFmyschool.Context;
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
            if (id == null)
            {
                return NotFound();
            }
            var schools = _context.Escuelas.Find(id);
            if (schools == null)
            {
                return NotFound();
            }

            return View(schools);

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
    }
}