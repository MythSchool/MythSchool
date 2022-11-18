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

        [HttpPost]
        public JsonResult LoginUser(string user, string password)
        {
            try
            {
                var response = _context.Usuario.Where(x => x.NicknameU == user && x.Contraseña == password).ToList();
                
                if (response.Count > 0)
                {
                    var usuario = _context.Usuario.Where(x => x.NicknameU == user && x.Contraseña == password && x.FkRol == 2).ToList();
                    if(usuario.Count > 0)
                    {
                        return Json(new { Success = 1 });
                    }
                    return Json(new { Success = 2 });
                }
                else
                {
                    return Json(new { Success = false });
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error" + ex.Message);

            }
        }

    }
}
