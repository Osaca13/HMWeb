using System;
using System.Collections.Generic;

namespace HMWeb.Biblioteca.Modelos
{
    public partial class Maquinarias
    {
        public int IdMaquinaria { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdCentro { get; set; }
        public int? IdServicio { get; set; }
        public string NumeroSerie { get; set; }
        public string Matricula { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string Activa { get; set; }
        public decimal? UltimaLecturaKms { get; set; }
        public decimal? UltimaLecturaHoras { get; set; }
        public string IndicaKH { get; set; }

        public virtual Centros IdCentroNavigation { get; set; }
        public virtual Empresas IdEmpresaNavigation { get; set; }
        public virtual Servicios IdServicioNavigation { get; set; }
    }
}
