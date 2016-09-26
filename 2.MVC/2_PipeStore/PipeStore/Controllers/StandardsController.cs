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
using PipeStore.Models;

namespace PipeStore.Controllers
{
    public class StandardsController : ApiController
    {
        private PipeDBContext db = new PipeDBContext();

        // GET: api/Standards
        public IQueryable<Standard> GetStandards()
        {
            return db.Standards;
        }

        // GET: api/Standards/5
        [ResponseType(typeof(Standard))]
        public IHttpActionResult GetStandard(int id)
        {
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return NotFound();
            }

            return Ok(standard);
        }

        // PUT: api/Standards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStandard(int id, Standard standard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != standard.Id)
            {
                return BadRequest();
            }

            db.Entry(standard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardExists(id))
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

        // POST: api/Standards
        [ResponseType(typeof(Standard))]
        public IHttpActionResult PostStandard(Standard standard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Standards.Add(standard);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = standard.Id }, standard);
        }

        // DELETE: api/Standards/5
        [ResponseType(typeof(Standard))]
        public IHttpActionResult DeleteStandard(int id)
        {
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return NotFound();
            }

            db.Standards.Remove(standard);
            db.SaveChanges();

            return Ok(standard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StandardExists(int id)
        {
            return db.Standards.Count(e => e.Id == id) > 0;
        }
    }
}