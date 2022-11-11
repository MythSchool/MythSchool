using System.ComponentModel.DataAnnotations;

namespace PFmyschool.Models
{
    public class Nivel
    {

        [Key]
        public int PkNivel { get; set; }
        public string NomNivel { get; set; }
    }
}
