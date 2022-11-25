using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PFmyschool.Models.Reporte
{
    public class ReporteEscuela
    {
       
        public int PkEscuela { get; set; }

        public string NomEscuela { get; set; }
        public string ImagEscuela { get; set; }

        public string NombreUbi { get; set; }

        public string NomLocalidad { get; set; }

        public string NomNivel { get; set; }

        public string NomSostenimiento { get; set; }
        public int PuntEscuela { get; set; }

    }
}
