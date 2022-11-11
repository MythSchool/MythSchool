using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFmyschool.Models
{
    public class Ubicacion
    {
        [Key]
        public int PkUbicacion { get; set; }

        public string NombreUbi { get; set; }

        [ForeignKey("Localidad")]

        public int FkLocalidad{ get; set; }

        public Localidad Localidad { get; set; }
    }
}
