using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Prueba_BACKEND_NET.Controllers
{
    /// <summary>
    /// Clase que implementa a el controlador de Word
    /// </summary>
    public class WordController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(Models.Parameter input)
        {
            HttpResponseMessage response = null;
            bool isValid = false;

            try
            {
                //si el input existe o no es null, es decir el modelo parameter no es null
                if (input != null)
                {
                    var data = input.data;

                    //si existe valor para data
                    if (data != null)
                    {
                        //llama al metodo que valida si son letras y de longitud 4
                        isValid = Validations(data);

                        //si es valido
                        if (isValid)
                        {
                            //se llama al metodo que llena el modelo y pasa a mayusculas
                            var result = Upper(data);

                            //crea la respuesta HTTP para retornar 200, pasando el modelo con la data
                            response = Request.CreateResponse(HttpStatusCode.OK, result);
                        }
                        //si no es valido
                        else
                            //crea la respuesta HTTP para retornar 400, pasando el modelo con la data
                            response = Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                    else
                        //crea la respuesta HTTP para retornar 400, pasando el modelo con la data
                        response = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
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
        /// Metodo que hace la validacion de la longitud y caracteres no numericos
        /// </summary>
        /// <param name="data">valor a validar</param>
        /// <returns>true: is valid; false: is not valid</returns>
        private bool Validations(string data)
        {
            Regex rgx = new Regex(@"^[a-zA-Z]{4}$");

            return rgx.IsMatch(data);
        }

        /// <summary>
        /// Metodo que convierte la data a mayusculas
        /// </summary>
        /// <param name="data">valor a convertir</param>
        /// <returns>Modelo con la respuesta</returns>
        private Models.Result Upper(string data)
        {
            return new Models.Result
            {
                code = "00",
                description = "OK",
                data = data.ToUpper()
            };
        }
    }


}
