using System;
using System.Collections.Generic;

#nullable disable

namespace Flock.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Logins = new HashSet<Login>();
        }

        public int CodEstado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? Fechabaja { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
