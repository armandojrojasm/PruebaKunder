using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba_BACKEND_NET.Controllers
{
    /// <summary>
    /// Clase que implementa a el controlador de Time
    /// </summary>
    public class TimeController : ApiController
    {
        [Route("api/time/{value?}")]
        [HttpGet]
        public HttpResponseMessage Get(string value)
        {
            HttpResponseMessage response = null;

            try
            {
                //convierto el valor de entrada a una fecha
                var inputDateTime = Convert.ToDateTime(value);

                //llamo al metodo que devuelve la hora UTC ISODATE
                var result = GetUTCISODATE(inputDateTime);

                //crea la respuesta HTTP para retornar 200, pasando el modelo con la data
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            //en caso de error
            catch (Exception ex)
            {
                //crea una respuesta, para retornar 500
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return response;
        }

        /// <summary>
        /// Metodo que obtiene la fecha para convertirla en UTC y obtener la hora
        /// </summary>
        /// <param name="date">Fecha</param>
        /// <returns>Modelo con la respuesta</returns>
        private Models.Result GetUTCISODATE(DateTime date)
        {
            //convierto date a una fecha UTC, obteniendo solo la hora
            var utc = date.ToUniversalTime().ToString("HH:mm:ssZ");

            //llena el modelo con la hora y la devuelve
            return new Models.Result {
                code = "00",
                description = "OK",
                data = utc
            };
        }
    }
}
