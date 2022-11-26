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
using PFmyschool.Models.Reporte;

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




        [HttpPost]

        public JsonResult OlvideContra(string correo)
        {
            try
            {
                var usuario = _context.Usuario.Where(x => x.CorreoUser == correo).ToList();
                if(usuario.Count > 0)
                {
                    return Json(new { Success = true });
                }
                return Json(new { Success = false });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }
        }


        [HttpPost]

        public JsonResult updatecontra(string correo, string contraseñaDes)
        {
            string contraseña = Encrip(contraseñaDes);

            try
            {
                connection.QueryAsync<Usuario>("Sp_RecuperarContraseña", new { correo, contraseña }, commandType: CommandType.StoredProcedure);
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

            string contraseña = Encrip(password);

            try
            {
                var response = _context.Usuario.Where(x => x.NicknameU == user && x.Contraseña == contraseña).ToList();

                if (response.Count > 0)
                {

                    var usuario = _context.Usuario.Where(x => x.NicknameU == user && x.Contraseña == contraseña && x.FkRol == 2).ToList();
                    if (usuario.Count > 0)
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



        public IActionResult Registro()
        {
            return View();
        }


        [HttpPost]

        public JsonResult RegistrarUsuario(string NombreUser, string ApellidoUser, string CorreoUser, string NicknameU, string ContraseñaDes)
        {

            string Contraseña = Encrip(ContraseñaDes);

            try
            {
                connection.QueryAsync<Usuario>("StpRegistro_Usuario", new { NombreUser, ApellidoUser, CorreoUser, NicknameU, Contraseña }, commandType: CommandType.StoredProcedure);
                return Json(new { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }
        }

        //Zona de Admin
        [HttpGet]
        public async Task<IActionResult> Bienvenido()
        {
            try
            {

                var response = await connection.QueryAsync<ReporteUsuarios>("SpGetUsuario", new { }, commandType: CommandType.StoredProcedure);

                return View(response);

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AdminEsc()
        {
            try
            {

                var response = await connection.QueryAsync<Escuelas>("SpGetEscuelas", new { }, commandType: CommandType.StoredProcedure);

                return View(response);

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AdminRol()
        {
            try
            {

                var response = await connection.QueryAsync<ReporteUsuarios>("SpGetRol", new { }, commandType: CommandType.StoredProcedure);

                return View(response);

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }
        }



        //Zona de Encriptado
        public string Encrip(string mensj)
        {
            string hasd = "codigo de c";
            byte[] data = UTF8Encoding.UTF8.GetBytes(mensj);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hasd));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);
        }

        public string DesEncip(string mensaj)
        {
            string hash = "coding con c";
            byte[] data = Convert.FromBase64String(mensaj);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }
    }
}
