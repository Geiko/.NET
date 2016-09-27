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
        public IQueryable<PipeStandard> GetStandards()
        {
            return db.PipeStandards;
        }

        // GET: api/Standards/5
        [ResponseType(typeof(PipeStandard))]
        public IHttpActionResult GetStandard(int id)
        {
            PipeStandard standard = db.PipeStandards.Find(id);
            if (standard == null)
            {
                return NotFound();
            }

            return Ok(standard);
        }

        // PUT: api/Standards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStandard(int id, PipeStandard standard)
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
        [ResponseType(typeof(PipeStandard))]
        public IHttpActionResult PostStandard(PipeStandard standard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PipeStandards.Add(standard);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = standard.Id }, standard);
        }

        // DELETE: api/Standards/5
        [ResponseType(typeof(PipeStandard))]
        public IHttpActionResult DeleteStandard(int id)
        {
            PipeStandard standard = db.PipeStandards.Find(id);
            if (standard == null)
            {
                return NotFound();
            }

            db.PipeStandards.Remove(standard);
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
            return db.PipeStandards.Count(e => e.Id == id) > 0;
        }
    }
}