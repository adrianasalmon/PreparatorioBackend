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
using APIPrueba.Models;

namespace APIPrueba.Controllers
{
    public class PruebasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Pruebas
        public IQueryable<Prueba> GetPruebas()
        {
            return db.Pruebas;
        }

        // GET: api/Pruebas/5
        [ResponseType(typeof(Prueba))]
        public IHttpActionResult GetPrueba(int id)
        {
            Prueba prueba = db.Pruebas.Find(id);
            if (prueba == null)
            {
                return NotFound();
            }

            return Ok(prueba);
        }

        // PUT: api/Pruebas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrueba(int id, Prueba prueba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prueba.SalmonID)
            {
                return BadRequest();
            }

            db.Entry(prueba).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PruebaExists(id))
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

        // POST: api/Pruebas
        [ResponseType(typeof(Prueba))]
        public IHttpActionResult PostPrueba(Prueba prueba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pruebas.Add(prueba);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prueba.SalmonID }, prueba);
        }

        // DELETE: api/Pruebas/5
        [ResponseType(typeof(Prueba))]
        public IHttpActionResult DeletePrueba(int id)
        {
            Prueba prueba = db.Pruebas.Find(id);
            if (prueba == null)
            {
                return NotFound();
            }

            db.Pruebas.Remove(prueba);
            db.SaveChanges();

            return Ok(prueba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PruebaExists(int id)
        {
            return db.Pruebas.Count(e => e.SalmonID == id) > 0;
        }
    }
}