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
        public string User { get; set; }
        public string Password { get; set; }
        [ForeignKey("Roles")]

        public int? FkRol { get; set; }

        public Rol Roles { get; set; }
    }
}
