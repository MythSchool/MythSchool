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
using System.Text;
using System.Security.Cryptography;

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


        [HttpPost]

        public JsonResult OlvideContra(string correo)
        {
            try
            {
                _context.Usuario.Where(x => x.CorreoUser == correo);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }
        }


        [HttpPost]

        public JsonResult updatecontra(string correo,string contraseña)
        {
            try
            {
                connection.QueryAsync<Usuario>("Sp_RecuperarContraseña", new { correo,contraseña }, commandType: CommandType.StoredProcedure);
                return Json(new { Success = true });
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
<<<<<<< HEAD


=======
>>>>>>> parent of 89bda36 (Dash)


        //Zona de Encriptado
        //public string Encrip (string mensj)
        //{
        //    string hasd = "codigo de c";
        //    byte[] data = UTF8Encoding.UTF8.GetBytes(mensj);

        //    MD5 md5 = MD5.Create();
        //    TripleDES tripledes = TripleDES.Create();

        //    tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hasd));
        //    tripledes.Mode = CipherMode.ECB;

        //    ICryptoTransform transform = tripledes.CreateEncryptor();
        //    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

        //    return Convert.ToBase64String(result);
        //}
        
        //public string DesEncip (string mensaj)
        //{
        //    string hash = "codigo de 2c";
        //    byte[] data = Convert.FromBase64String(mensaj);

        //    MD5 md5 = MD5.Create();
        //    TripleDES tripledes = TripleDES.Create();

        //    tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
        //    tripledes.Mode = CipherMode.ECB;

        //    ICryptoTransform transform = tripledes.CreateEncryptor();
        //    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

        //    return Convert.ToBase64String(result);
        //}
    }
}
