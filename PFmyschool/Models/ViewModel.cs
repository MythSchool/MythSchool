using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFmyschool.Models
{
    public class ViewModel
    {
        public Escuelas escuelas { get; set; }
        public Ubicacion ubicacion { get; set; }
        public Nivel nivel { get; set; }
        public Sostenimiento sostenimiento { get; set; }

        public Localidad local { get; set; }
        public IEnumerable<OfertasEdu> ofertas { get; set; }
    }
}
