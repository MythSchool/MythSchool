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
using Microsoft.AspNetCore.Mvc.Rendering;

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

                var response = await connection.QueryAsync<Rol>("SpGetRol", new { }, commandType: CommandType.StoredProcedure);

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

        [HttpGet]
        public IActionResult CrearRol()
        {
            return View();
        }


        public async Task<IActionResult> CrearRolES(Rol request)
        {
            if (request != null)
            {
                Rol rol = new Rol();
                rol.Nombre = request.Nombre;

                _context.Rol.Add(request);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminRol));
            }
            return View();
        }







        [HttpGet]

        public IActionResult EditarRol(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rol = _context.Rol.Find(id);

            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);

        }


        [HttpPost]

        public async Task<ActionResult> EditarRolES(Rol response)
        {
            Rol rol = new Rol();
            rol = _context.Rol.Find(response.PkRol);

            if (rol != null)
            {
                rol.Nombre = response.Nombre;

                _context.Entry(rol).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminRol));
            }

            return NotFound();

        }






        [HttpGet]
        public async Task<ActionResult> EliminarUsuario(int? id)
        {
            Usuario user = new Usuario();
            user = _context.Usuario.Find(id);
            if (user != null)
            {
                _context.Usuario.Remove(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Bienvenido));
            }

            return NotFound();

        }



        [HttpGet]
        public async Task<ActionResult> EliminarEscuela(int? id)
        {
            Escuelas escuela = new Escuelas();
            escuela = _context.Escuelas.Find(id);
            if (escuela != null)
            {
                _context.Escuelas.Remove(escuela);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminEsc));
            }

            return NotFound();

        }



        [HttpGet]
        public IActionResult RegistrarEsc()
        {
            ViewBag.Ubicacion = _context.Ubicacion.Select(p => new SelectListItem()
            {
                Text = p.NombreUbi,
                Value = p.PkUbicacion.ToString()
            });


            ViewBag.Nivel = _context.Nivel.Select(p => new SelectListItem()
            {
                Text = p.NomNivel,
                Value = p.PkNivel.ToString()
            });


            ViewBag.Sostenimiento = _context.Sostenimiento.Select(p => new SelectListItem()
            {
                Text = p.NomSostenimiento,
                Value = p.PkSostenimiento.ToString()
            });

            return View();
        }


        public async Task<IActionResult> RegistrarEscuela(Escuelas request)
        {
            if (request.FkUbicacion <= 0 || request.FkNivel <= 0 || request.FkUbicacion <= 0)
            {
                return RedirectToAction(nameof(RegistrarEsc));
            }
            else
            {
                try
                {

                    var response = await connection.QueryAsync<Escuelas>("StpInsertar_Escuela", new { request.NomEscuela, request.ImagEscuela, request.DescEscuela, request.PuntEscuela, request.LinkEscuela, request.FkUbicacion, request.FkNivel, request.FkSostenimiento }, commandType: CommandType.StoredProcedure);

                    return RedirectToAction(nameof(AdminEsc));

                }
                catch (Exception ex)
                {
                    throw new Exception("Surgio un error " + ex.Message);
                }
            }
          
        }


        [HttpGet]
        public IActionResult EditUser(int? id)
        {
         

            if (id == null)
            {
                return NotFound();
            }
            var rol = _context.Usuario.Find(id);

            if (rol == null)
            {
                return NotFound();
            }

            ViewBag.Rol = _context.Rol.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRol.ToString()
            });
            return View(rol);
        }

        [HttpPost]

        public async Task<ActionResult> EditarUsuario(Usuario response)
        {
            Usuario usuario = new Usuario();
            usuario = _context.Usuario.Find(response.PkUsuario);
            string Con = Encrip(response.Contraseña);
            if (usuario != null)
            {
                usuario.NombreUser = response.NombreUser;
                usuario.ApellidoUser = response.ApellidoUser;
                usuario.CorreoUser = response.CorreoUser;
                usuario.FotoperfUser = response.FotoperfUser;
                usuario.NicknameU=response.NicknameU;
                usuario.Contraseña = Con;
                usuario.FkRol = response.FkRol;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Bienvenido));
            }

            return NotFound();

        }
        
        [HttpGet]
        public IActionResult RegistrarOfer()
        {
            ViewBag.Escuelas = _context.Escuelas.Select(p => new SelectListItem()
            {
                Text = p.NomEscuela,
                Value = p.PkEscuela.ToString()
            });

            return View();
        }


        public async Task<IActionResult> RegistrarOfertaE(OfertasEdu request)
        {
            if(request.FkEscuela <= 0)
            {
                return RedirectToAction(nameof(RegistrarOfer));
            }
            else
            {
                try
                {

                    var response = await connection.QueryAsync<OfertasEdu>("Sp_InsertarOfertasEdu", new { request.NomOferta, request.DescOferta, request.FkEscuela }, commandType: CommandType.StoredProcedure);

                    return RedirectToAction(nameof(AdminCarreras));

                }
                catch (Exception ex)
                {
                    throw new Exception("Surgio un error " + ex.Message);
                }
            }

          
        }
        [HttpGet]
        public IActionResult EditarEsc(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuela = _context.Escuelas.Find(id);

            if (escuela == null)
            {
                return NotFound();
            }
            ViewBag.Ubicacion = _context.Ubicacion.Select(p => new SelectListItem()
            {
                Text = p.NombreUbi,
                Value = p.PkUbicacion.ToString()
            });

            ViewBag.Nivel = _context.Nivel.Select(p => new SelectListItem()
            {
                Text = p.NomNivel,
                Value = p.PkNivel.ToString()
            });

            ViewBag.Sostenimiento = _context.Sostenimiento.Select(p => new SelectListItem()
            {
                Text = p.NomSostenimiento,
                Value = p.PkSostenimiento.ToString()
            });

            return View(escuela);

        }

        [HttpPost]
        public async Task<ActionResult> EditarEscuelas(Escuelas i)
        {
            try
            {
                await connection.QueryAsync<Usuario>("StpUpdate_Escuela", new
                {
                    i.PkEscuela,
                    i.NomEscuela,
                    i.ImagEscuela,
                    i.DescEscuela,
                    i.PuntEscuela,
                    i.LinkEscuela,
                    i.FkUbicacion,
                    i.FkNivel,
                    i.FkSostenimiento
                }, commandType: CommandType.StoredProcedure);
                return RedirectToAction(nameof(AdminEsc));

            }
            catch (Exception ex)
            {
                throw new System.Exception("Surgio un problema" + ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AdminCarreras()
        {
            try
            {

                var response = await _context.OfertasEdu.Include(x => x.Escuelas).ToListAsync();

                return View(response);

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }
        }



        [HttpGet]
        public IActionResult EditarCar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuela = _context.OfertasEdu.Find(id);

            if (escuela == null)
            {
                return NotFound();
            }
            return View(escuela);

        }

        [HttpPost]
        public async Task<ActionResult> EditarCarrera(OfertasEdu i)
        {
            try
            {
                await connection.QueryAsync<OfertasEdu>("Stp_UpdateOferta", new
                {
                    i.PkOfertasEdu,
                    i.NomOferta,
                    i.DescOferta
                }, commandType: CommandType.StoredProcedure);
                return RedirectToAction(nameof(AdminCarreras));

            }
            catch (Exception ex)
            {
                throw new System.Exception("Surgio un problema" + ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult> EliminarOferta(int? id)
        {
            OfertasEdu oferta = new OfertasEdu();
            oferta = _context.OfertasEdu.Find(id);
            if (oferta != null)
            {
                _context.OfertasEdu.Remove(oferta);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminCarreras));
            }

            return NotFound();

        }






    }
}
