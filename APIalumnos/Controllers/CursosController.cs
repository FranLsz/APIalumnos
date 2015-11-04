using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIalumnos.Models;

namespace APIalumnos.Controllers
{
    public class CursosController : ApiController
    {
        private Alumno15Entities db;

        public CursosController()
        {
            db = new Alumno15Entities();
        }

        public IQueryable<Curso> Get()
        {
            return db.Curso;
        }

        [ResponseType(typeof(Curso))]

        public IHttpActionResult GetPorId(int id)
        {
            var data = db.Curso.Find(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }


    }
}
