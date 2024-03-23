using Microsoft.EntityFrameworkCore;
using MilesCarRental.Data;
using MilesCarRental.Models;

namespace MilesCarRental.Services
{
    public class LocalidadService : ILocalidadService
    {
        private readonly DataContext _context;

        public LocalidadService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Localidad> GetLocalidades()
        {
            return _context.Localidades.ToList();
        }

        public Localidad GetLocalidad(int id)
        {
            return _context.Localidades.Find(id);
        }

        public Localidad CreateLocalidad(Localidad localidad)
        {
            _context.Localidades.Add(localidad);
            _context.SaveChanges();
            return localidad;
        }

        public void UpdateLocalidad(int id, Localidad localidad)
        {
            _context.Entry(localidad).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteLocalidad(int id)
        {
            var localidad = _context.Localidades.Find(id);
            if (localidad != null)
            {
                _context.Localidades.Remove(localidad);
                _context.SaveChanges();
            }
        }
    }
}
