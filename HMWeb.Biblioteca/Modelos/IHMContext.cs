using Microsoft.EntityFrameworkCore;

namespace HMWeb.Biblioteca.Modelos
{
    public interface IHMContext
    {
        DbSet<Centros> Centros { get; set; }
        DbSet<Empresas> Empresas { get; set; }
        DbSet<Maquinarias> Maquinarias { get; set; }
        DbSet<Servicios> Servicios { get; set; }
    }
}