using WebApiPeluqueria.Data.Models;

namespace WebApiPeluqueria.Data.Repository
{
    public interface IServicioRepositorio
    {
        List<Servicio> GetAll();
        List<Servicio> GetByFillters(int idRol);
        Servicio? GetById(int id);
        void Save(Servicio servicio);
        void Remove(int id);
    }
}
