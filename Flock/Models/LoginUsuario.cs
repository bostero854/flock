using System.ComponentModel.DataAnnotations;

namespace Flock.Models
{
    public class LoginUsuario
    {
        [Required]
        public string Nick { get; set; }
        [Required]
        public string Clave { get; set; }
    }
}
