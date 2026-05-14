using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISFDyT93.Controlador.Controllers
{
    public class ValuesController : ApiController
    {

        [HttpGet]
        [Route("api/values/GetParametros")]
        [Authorize]
        public IList<ParametrosModelo> GetParametros()
        {
            ParametrosLogica param = new ParametrosLogica();
            return param.ObtenerParametros();
            
        }

      
    }
}
