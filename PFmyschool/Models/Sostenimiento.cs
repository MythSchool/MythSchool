using System.ComponentModel.DataAnnotations;

namespace PFmyschool.Models
{
    public class Sostenimiento
    {

        [Key]
        public int PkSostenimiento { get; set; }

        public string NomSostenimiento { get; set; }
    }
}
