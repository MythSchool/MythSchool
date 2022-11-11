using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFmyschool.Models
{
    public class Localidad
    {
        [Key]
        public int PkLocalidad { get; set; }

        public string NomLocalidad { get; set; }


    }
}
