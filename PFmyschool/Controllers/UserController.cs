using PFmyschool.Context;
using PFmyschool.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
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

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2NBP7F1; initial catalog=MythSchoolDB; Integrated Security= True");
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }


        [HttpPost]

        public JsonResult RegistrarUsuario(string NombreUser,string ApellidoUser,string CorreoUser,string NicknameU,string Contraseña)
        {
          try
            {
                connection.QueryAsync<Usuario>("StpRegistro_Usuario", new { NombreUser, ApellidoUser, CorreoUser, NicknameU, Contraseña }, commandType: CommandType.StoredProcedure);
                return Json(new { Success = true});
            }
                catch (Exception ex)
                {
                return Json(new { Success = false });
            }
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


        [HttpGet]

        public IActionResult Session(string user)
        {
            var session = _context.Usuario.Find(user);
            return View(session);
        }





        [HttpPost]
        public JsonResult verifUser(string correo, string user)
        {

            try
            {
                var response = _context.Usuario.Where(x => x.NicknameU == user && x.CorreoUser == correo).ToList();

                if (response.Count > 0)
                {
                    return Json(new { Success = true });
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
