using MilesCarRental.Models;

namespace MilesCarRental.Services
{
    public interface ILocalidadService
    {
        IEnumerable<Localidad> GetLocalidades();
        Localidad GetLocalidad(int id);
        Localidad CreateLocalidad(Localidad localidad);
        void UpdateLocalidad(int id, Localidad localidad);
        void DeleteLocalidad(int id);
    }
}
