using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flock.Models
{
    public class Provincia
    {
        /// <summary>
        /// Centroide
        /// </summary>
        public Centroide Centroide { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Nombre de provincia
        /// </summary>
        public string Nombre { get; set; }
    }
}
