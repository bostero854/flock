using System;
using System.Collections.Generic;

#nullable disable

namespace Flock.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string NroDireccion { get; set; }
        public int CodPerfil { get; set; }

        public virtual Perfil CodPerfilNavigation { get; set; }
        public virtual Login IdUsuarioNavigation { get; set; }
        public virtual Documento TipoDocumentoNavigation { get; set; }
    }
}
