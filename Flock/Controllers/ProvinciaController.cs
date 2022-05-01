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

        /// <summary>
        /// Se obtiene latitud y longitud sincronico
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(Models.Georreferenciacion))]
        [HttpGet("latlong/{nombre}")]
        public IActionResult Get(string nombre)
        {
            try
            {
                return Ok(_provincia.LatLonAsync(nombre));

            }
            catch (Exception ex)
            {
                _logger.LogError("Controlador", ex);
                throw;
            }

        }
        /// <summary>
        /// Se obtiene latitud y longitud asincronico
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        /// <summary> Se obtiene una operación por Id Pom </summary>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. Operacion Inexistente.</response>
        /// <response code="400">Bad request. Se generó un error en con la información requerida.</response>
        /// <response code="401">Unauthorized. Falló la autenticación.</response>
        [Produces("application/json", Type = typeof(Models.Georreferenciacion))]
        [HttpGet("latlongAsync/{nombre}")]
        
        public async Task<IActionResult> GetAsync(string nombre)
        {
            try
            {
                var resul = await _provincia.LatLonAsync(nombre);
                return Ok(resul);

            }
            catch (Exception ex)
            {
                _logger.LogError("Controlador", ex);
                throw;
            }

        }
    }
}
