using Microsoft.EntityFrameworkCore;
using WebApiPeluqueria.Data.Models;

namespace WebApiPeluqueria.Data.Repository
{
    public class ServicioRepositorio : IServicioRepositorio
    {
        private readonly ServicioDbContext _context;

        public ServicioRepositorio(ServicioDbContext context)
        {
            _context = context;
        }

        public List<Servicio> GetAll()
        {
            return _context.Servicios.ToList();
        }

        public List<Servicio> GetByFillters(int IdServicio)
        {
            return _context.Servicios.Where(x => x.Id == IdServicio).ToList();
        }

        public Servicio? GetById(int id)
        {
            return _context.Servicios.Find(id);
        }

        public void Remove(int id)
        {
            var serv = GetById(id);
            _context.Servicios.Remove(serv);
            _context.SaveChanges();
        }

        public void Save(Servicio servicio)
        {
            if (servicio == null)
            {
                _context.Servicios.Add(servicio);
            }
            else
            {
                _context.Servicios.Update(servicio);
            }
            _context.SaveChanges();
        }
    }
}
