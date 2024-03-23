using Microsoft.EntityFrameworkCore;
using MilesCarRental.Data;
using MilesCarRental.Models;
using System;

namespace MilesCarRental.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly DataContext _context;

        public VehiculoService(DataContext context)
        {
            _context = context;
        }

        public List<Vehiculo> ObtenerVehiculosDisponibles(string localidadRecogida, string localidadDevolucion)
        {

            return _context.Vehiculos
                .Where(v => v.LocalidadRecogida.Nombre == localidadRecogida && v.LocalidadDevolucion.Nombre == localidadDevolucion)
                .ToList();
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculosAsync()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        public async Task<Vehiculo> GetVehiculoByIdAsync(int id)
        {
            return await _context.Vehiculos.FindAsync(id);
        }

        public async Task CreateVehiculoAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehiculoAsync(Vehiculo vehiculo)
        {
            _context.Entry(vehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehiculoAsync(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
