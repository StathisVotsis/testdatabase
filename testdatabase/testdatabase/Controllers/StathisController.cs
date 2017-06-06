using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testdatabase.Controllers
{
    [RoutePrefix("api/Test")]
    public class StathisController : ApiController
    {
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, "Stathis ok");
           
        }

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            int i = id + 1;
            return Request.CreateResponse(HttpStatusCode.OK, i);

        }
    }
}
