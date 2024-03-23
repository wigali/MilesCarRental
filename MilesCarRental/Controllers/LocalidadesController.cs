using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Models;
using MilesCarRental.Services;

namespace MilesCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        private readonly ILocalidadService _localidadService;

        public LocalidadesController(ILocalidadService localidadService)
        {
            _localidadService = localidadService;
        }

        // GET: api/Localidades
        [HttpGet("ObtenerLocalidades")]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetLocalidades()
        {
            var localidades = _localidadService.GetLocalidades();
            return Ok(localidades);
        }

        // GET: api/Localidades/5
        [HttpGet("BuscarLocalidad/{id}")]
        public async Task<ActionResult<Localidad>> GetLocalidad(int id)
        {
            var localidad = _localidadService.GetLocalidad(id);
            if (localidad == null)
            {
                return NotFound();
            }
            return localidad;
        }

        // POST: api/Localidades
        [HttpPost("CrearLocalidad")]
        public async Task<ActionResult<Localidad>> PostLocalidad(Localidad localidad)
        {
            _localidadService.CreateLocalidad(localidad);
            return CreatedAtAction(nameof(GetLocalidad), new { id = localidad.Id }, localidad);
        }

        // PUT: api/Localidades/5
        [HttpPut("ActualizarLocalidad{id}")]
        public async Task<IActionResult> PutLocalidad(int id, Localidad localidad)
        {
            if (id != localidad.Id)
            {
                return BadRequest();
            }
            _localidadService.UpdateLocalidad(id, localidad);
            return NoContent();
        }

        // DELETE: api/Localidades/5
        [HttpDelete("DeleteLocalidad/{id}")]
        public async Task<IActionResult> DeleteLocalidad(int id)
        {
            var localidad = _localidadService.GetLocalidad(id);
            if (localidad == null)
            {
                return NotFound();
            }
            _localidadService.DeleteLocalidad(id);
            return NoContent();
        }
    }
}
