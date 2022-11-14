using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PFmyschool.Models
{
    public class Usuario
    {
        [Key]
        public int PkUsuario { get; set; }
        public string NombreUser { get; set; }
        public string ApellidoUser { get; set; }
        public string CorreoUser { get; set; }
        public string? FotoperfUser { get; set; }

        public string NicknameU { get; set; }

        public string Contraseña { get; set; }
        [ForeignKey("Rol")]

        public int? FkRol { get; set; }

        public Rol Rol { get; set; }
    }
}
