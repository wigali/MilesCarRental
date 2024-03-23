namespace MilesCarRental.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int LocalidadRecogidaId { get; set; }
        public Localidad LocalidadRecogida { get; set; }
        public int LocalidadDevolucionId { get; set; }
        public Localidad LocalidadDevolucion { get; set; }
    }
}
