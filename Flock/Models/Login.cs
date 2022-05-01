using System;
using System.Collections.Generic;

#nullable disable

namespace Flock.Models
{
    public partial class Login
    {
        public Login()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdLogin { get; set; }
        public int IdUsuario { get; set; }
        public string Nick { get; set; }
        public string Clave { get; set; }
        public int CodEstado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Estado CodEstadoNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
