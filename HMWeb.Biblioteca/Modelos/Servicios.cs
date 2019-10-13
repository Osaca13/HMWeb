using System;
using System.Collections.Generic;

namespace HMWeb.Biblioteca.Modelos
{
    public partial class Servicios
    {
        public Servicios()
        {
            Maquinarias = new HashSet<Maquinarias>();
        }

        public int IdServicio { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Maquinarias> Maquinarias { get; set; }
    }
}
