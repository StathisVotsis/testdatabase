﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stathis.Repository;
using Stathis.Models;

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
            var customerRepo = new CustomerRepository();
            return Request.CreateResponse(HttpStatusCode.OK, customerRepo.GetById(id));
//
        }

        /* [Route("{name:string}")]
         [HttpGet]
         public HttpResponseMessage GetByString(string name)
         {
             var customerRepo = new CustomerRepository();
             return Request.CreateResponse(HttpStatusCode.OK, customerRepo.GetByString(name));

         }*/
        [Route()]
        [HttpPost]
        public HttpResponseMessage Postitem([FromBody] Customer customer)
        {
            var customerRepo = new CustomerRepository();
            customerRepo.Insert(customer.Id);


            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [Route("{Id:int}")]
        [HttpPut]
        public HttpResponseMessage PutItem(int Id)
        {
            var customerRepo = new CustomerRepository();
            customerRepo.Update(Id);


            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

    }
}
