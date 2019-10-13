using System;
using System.Collections.Generic;

namespace HMWeb.Biblioteca.Modelos
{
    public partial class Centros
    {
        public Centros()
        {
            Maquinarias = new HashSet<Maquinarias>();
        }

        public int IdCentro { get; set; }
        public int? IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public int? DesfaseMinutosTurno { get; set; }
        public string ReferenciaRrhh { get; set; }
        public string EmailRrhh { get; set; }
        public string EmailPlanesAccion { get; set; }

        public virtual Empresas IdEmpresaNavigation { get; set; }
        public virtual ICollection<Maquinarias> Maquinarias { get; set; }
    }
}
