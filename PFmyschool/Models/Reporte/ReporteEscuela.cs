using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PFmyschool.Models.Reporte
{
    public class ReporteEscuela
    {
       
        public int PkEscuela { get; set; }

        public int FkUbicacion { get; set; }

        public int FkNivel { get; set; }

        public int FkSostenimiento { get; set; }

        public string NomEscuela { get; set; }
        public string ImagEscuela { get; set; }

        public string NombreUbi { get; set; }

        public string NomLocalidad { get; set; }

        public string NomNivel { get; set; }

        public string NomSostenimiento { get; set; }
        public int PuntEscuela { get; set; }


        public string NomOferta { get; set; }
    }
}
