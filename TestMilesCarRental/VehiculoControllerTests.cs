using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Controllers;
using MilesCarRental.Models;
using MilesCarRental.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMilesCarRental
{
    internal class VehiculoControllerTests
    {
        [Test]
        public async Task BuscarVehiculosDisponibles_DebeRetornarOkConListaVehiculos()
        {
            // Arrange
            var mockService = new Mock<IVehiculoService>();
            var vehiculos = new List<Vehiculo>(); // Define vehículos de prueba
            mockService.Setup(service => service.GetVehiculosAsync())
                       .ReturnsAsync(vehiculos);

            var controller = new VehiculoController(mockService.Object);

            // Act
            var result = controller.ObtenerVehiculosDisponibles("Bogotá", "Medellín");

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<List<Vehiculo>>(okResult.Value);
            var vehiculosResult = (List<Vehiculo>)okResult.Value;
            // Aquí puedes agregar más aserciones para verificar los datos retornados
        }
    }
}
