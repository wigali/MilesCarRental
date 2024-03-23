using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilesCarRental.Models;
using MilesCarRental.Services;

namespace MilesCarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet("ObtenerVehiculosDisponibles")]
        public IActionResult ObtenerVehiculosDisponibles(string localidadRecogida, string localidadDevolucion)
        {
            var vehiculos = _vehiculoService.ObtenerVehiculosDisponibles(localidadRecogida, localidadDevolucion);
            return Ok(vehiculos);
        }

        [HttpGet("ObtenerTodosVehiculos")]
        public async Task<IEnumerable<Vehiculo>> GetVehiculosAsync()
        {
            return await _vehiculoService.GetVehiculosAsync();
        }

        // GET: api/Vehiculos/5
        [HttpGet("ObtenerVehiculo{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _vehiculoService.GetVehiculoByIdAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return vehiculo;
        }

        // POST: api/Vehiculos
        [HttpPost("CrearVehiculo")]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
            await _vehiculoService.CreateVehiculoAsync(vehiculo);
            return CreatedAtAction(nameof(GetVehiculo), new { id = vehiculo.Id }, vehiculo);
        }

        // PUT: api/Vehiculos/5
        [HttpPut("ActualizarVehiculo{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return BadRequest();
            }
            await _vehiculoService.UpdateVehiculoAsync(vehiculo);
            return NoContent();
        }

        // DELETE: api/Vehiculos/5
        [HttpDelete("EliminarVehiculo{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _vehiculoService.GetVehiculoByIdAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            await _vehiculoService.DeleteVehiculoAsync(id);
            return NoContent();
        }

    }
}
