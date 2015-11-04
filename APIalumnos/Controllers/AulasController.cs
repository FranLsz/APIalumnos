using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIalumnos.Models;

namespace APIalumnos.Controllers
{
    public class AulasController : ApiController
    {
        private Alumno15Entities db = new Alumno15Entities();

        // GET: api/Aulas
        public IQueryable<Aula> GetAula()
        {
            return db.Aula;
        }

        [HttpGet]
        public IQueryable<Aula> ObtenerPorDimension(int dim)
        {
            return db.Aula.Where(o=>o.capacidad>=dim);
        }

        public IQueryable<Aula> GetAulaNombre(String nombre)
        {
            return db.Aula.Where(o => o.nombre.Contains(nombre));
        }

        // GET: api/Aulas/5
        [ResponseType(typeof(Aula))]
        public IHttpActionResult GetAula(int id)
        {
            Aula aula = db.Aula.Find(id);
            if (aula == null)
            {
                return NotFound();
            }

            return Ok(aula);
        }

        // PUT: api/Aulas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAula(int id, Aula aula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aula.idAula)
            {
                return BadRequest();
            }

            db.Entry(aula).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AulaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Aulas
        [ResponseType(typeof(Aula))]
        public IHttpActionResult PostAula(Aula aula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aula.Add(aula);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aula.idAula }, aula);
        }

        // DELETE: api/Aulas/5
        [ResponseType(typeof(Aula))]
        public IHttpActionResult DeleteAula(int id)
        {
            Aula aula = db.Aula.Find(id);
            if (aula == null)
            {
                return NotFound();
            }

            db.Aula.Remove(aula);
            db.SaveChanges();

            return Ok(aula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AulaExists(int id)
        {
            return db.Aula.Count(e => e.idAula == id) > 0;
        }
    }
}