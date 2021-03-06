﻿using Stathis.Models;
using Stathis.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testdatabase.Controllers
{
    [RoutePrefix("api/Test2")]
    public class Stathis2Controller : ApiController
    {

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {

            return Request.CreateResponse(HttpStatusCode.OK, "Stathis ok");

        }

        [Route()]
        [HttpPost]
        public HttpResponseMessage Postitem([FromBody] Customer customer)
        {
            var customerRepo = new CustomerRepository();
            customerRepo.Insert2(customer);


            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [Route("{id:int}")]
        [HttpPut]
        public HttpResponseMessage Putitem([FromUri]int id,[FromBody]string Name)
        {
            var customerRepo = new CustomerRepository();
            customerRepo.Update2(id,Name);
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }
    }
}
