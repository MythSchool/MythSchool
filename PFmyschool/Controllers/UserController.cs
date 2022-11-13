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

namespace PFmyschool.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController124


        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;


        public UserController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult OlvContra()
        {
            return View();
        }


        public IActionResult Main()
        {
            return View();
        }


        [HttpGet]

        public IActionResult Menu(Usuario request)
        {
            if (request == null)
            {
                return NotFound();
            }
            var usuario = _context.Usuario.Find(request.User);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return View();
            }


        }

    }
}
