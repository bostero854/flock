using System.Collections.Generic;

namespace Flock.Models
{
    public class Georreferenciacion
    {
        /// <summary>
        /// Cantidad de registros
        /// </summary>
        public int Cantidad { get; set; }
        public int Inicio { get; set; }
        public Parametro Parametros { get; set; }
        /// <summary>
        /// Retorna una lista
        /// </summary>
        public List<Provincia> Provincias { get; set; }
        /// <summary>
        /// Cantidad de registros
        /// </summary>
        public int Total { get; set; }
    }
}
