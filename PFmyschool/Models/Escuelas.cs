﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFmyschool.Models
{
    public class Escuelas
    {
        [Key]
        public int PkEscuela { get; set; }

        public string NomEscuela { get; set; }

        public string? ImagEscuela { get; set; }

        public string DescEscuela { get; set; }

        public int PuntEscuela { get; set; }

        public string LinkEscuela { get; set; }

        [ForeignKey("Ubicacion")]

        public int FkUbicacion { get; set; }

        public Ubicacion Ubicacion { get; set; }

        [ForeignKey("Sostenimiento")]

        public int FkSostenimiento { get; set; }

        public Sostenimiento Sostenimiento { get; set; }

        [ForeignKey("Nivel")]

        public int FkNivel { get; set; }

        public Nivel Nivel { get; set; }


    }
}
