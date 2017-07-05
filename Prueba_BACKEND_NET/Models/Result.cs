using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_BACKEND_NET.Models
{
    /// <summary>
    /// Clase que implementa el modelo del resultado.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Propiedad con el codigo del resultado.
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// Propiedad con la descripcion del resultado.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Propiedad con el valor de la data de salida.
        /// </summary>
        public string data { get; set; }
    }
}