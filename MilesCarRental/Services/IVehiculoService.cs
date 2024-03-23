using MilesCarRental.Models;

namespace MilesCarRental.Services
{
    public interface IVehiculoService
    {
        List<Vehiculo> ObtenerVehiculosDisponibles(string localidadRecogida, string localidadDevolucion);
        Task<IEnumerable<Vehiculo>> GetVehiculosAsync();
        Task<Vehiculo> GetVehiculoByIdAsync(int id);
        Task CreateVehiculoAsync(Vehiculo vehiculo);
        Task UpdateVehiculoAsync(Vehiculo vehiculo);
        Task DeleteVehiculoAsync(int id);
    }
}
