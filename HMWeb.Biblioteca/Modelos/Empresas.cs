using System;
using System.Collections.Generic;

namespace HMWeb.Biblioteca.Modelos
{
    public partial class Empresas
    {
        public Empresas()
        {
            Centros = new HashSet<Centros>();
            Maquinarias = new HashSet<Maquinarias>();
        }

        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public int? IdEmisor { get; set; }
        public string Logotipo { get; set; }
        public string ReferenciaRrhh { get; set; }

        public virtual ICollection<Centros> Centros { get; set; }
        public virtual ICollection<Maquinarias> Maquinarias { get; set; }
    }
}
