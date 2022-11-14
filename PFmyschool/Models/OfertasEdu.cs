using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFmyschool.Models
{
    public class OfertasEdu
    {

        [Key]
        public int PkOfertasEdu { get; set; }

        public string NomOferta { get; set; }

        public string DescOferta { get; set; }

        [ForeignKey("Escuelas")]

        public int FkEscuela { get; set; }

        public Escuelas Escuelas { get; set; }
    }
}
