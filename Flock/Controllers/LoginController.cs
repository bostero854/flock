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
    [Route("api/flock")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuario _usuario;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IUsuario usuario, ILogger<LoginController> logger)
        {
            _usuario = usuario;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] Models.LoginUsuario loginUsuario)
        {
            try
            {
                return Ok(_usuario.GetUsuario(loginUsuario));

            }
            catch (Exception ex)
            {
                _logger.LogError("Controlador", ex);
                throw;
            }

        }
    }
}
