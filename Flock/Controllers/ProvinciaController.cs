using Flock.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flock.Controllers
{
    [Route("api/provincia")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvincia _provincia;
        private readonly ILogger<ProvinciaController> _logger;

        public ProvinciaController(IProvincia provincia, ILogger<ProvinciaController> logger)
        {
            _provincia = provincia;
            _logger = logger;
        }

        [HttpGet("latlong/{nombre}")]
        public IActionResult Post(string nombre)
        {
            try
            {
                return Ok(_provincia.LatLonAsync(nombre));

            }
            catch (Exception ex)
            {
                //_logger.LogError("Controlador", ex);
                throw;
            }

        }
        [HttpGet("latlongAsync/{nombre}")]
        public async Task<IActionResult> PostAsync(string nombre)
        {
            try
            {
                var resul = await _provincia.LatLonAsync(nombre);
                return Ok(resul);

            }
            catch (Exception ex)
            {
                //_logger.LogError("Controlador", ex);
                throw;
            }

        }
    }
}
