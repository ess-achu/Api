using ApiStudent.Models;
using ApiStudent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ApiStudent.Controllers
{

    
    public class StudentController : ApiController
    {
        StudentRepository db = new StudentRepository();


        [HttpGet]
        [Route("api/AllStudents")]
        public IHttpActionResult Get()
        {
            var data = db.Get();
            return Json(data);
        }

        [HttpPost]
        [Route("api/AllStudents")]
        public IHttpActionResult Post(int id,string name)
        {
            var i = db.Put(id,name);
            return Ok(i);
        }
    }
}
