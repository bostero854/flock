using System;
using System.Collections.Generic;

#nullable disable

namespace Flock.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int CodPerfil { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
