using System.Collections.Generic;

namespace Flock.Models
{
    public class Georreferenciacion
    {
        public int Cantidad { get; set; }
        public int Inicio { get; set; }
        public Parametro Parametros { get; set; }
        public List<Provincia> Provincias { get; set; }
        public int Total { get; set; }
    }
}
