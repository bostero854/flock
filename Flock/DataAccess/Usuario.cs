using Flock.IServices;
using Flock.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flock.DataAccess
{
    public class Usuario: IUsuario
    {
        //private readonly ILogger<Usuario> _logger;
        private readonly Serilog.ILogger _logger;
        private readonly flockContext _flock;

        public Usuario(Serilog.ILogger logger, flockContext flock)
        {
            _logger = logger;
            _flock = flock;
        }

        public Models.Usuario GetUsuario(Models.LoginUsuario loginUsuario) 
        {
            try
            {
                _logger.Information("Inicio");
                var _login = _flock.Logins.Where(x => x.Nick.Equals(loginUsuario.Nick) && x.Clave.Equals(Seguridad.Clave.Sha256_hash(loginUsuario.Clave))).FirstOrDefault();

                if (_login is object)
                {
                    return _flock.Usuarios.Where(x => x.IdUsuario.Equals(_login.IdUsuario)).FirstOrDefault();
                }
                else 
                {
                    return null;
                }
                

            }
            catch (Exception)
            {

                throw;
            }
        } 
    }
}
