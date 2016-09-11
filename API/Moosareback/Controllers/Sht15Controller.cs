using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Moosareback.Models;

namespace Moosareback.Controllers
{
    public class Sht15Controller : ApiController
    {
        private ReadingsContext db = new ReadingsContext();

        // GET: api/Sht15
        public IQueryable<Sht15> GetSht15()
        {
            return db.Sht15;
        }

        // GET: api/Sht15/5
        [ResponseType(typeof(Sht15))]
        public async Task<IHttpActionResult> GetSht15(string id)
        {
            Sht15 sht15 = await db.Sht15.FindAsync(id);
            if (sht15 == null)
            {
                return NotFound();
            }

            return Ok(sht15);
        }

        // PUT: api/Sht15/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSht15(Guid id, Sht15 sht15)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sht15.Id)
            {
                return BadRequest();
            }

            db.Entry(sht15).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sht15Exists(id))
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

        // POST: api/Sht15
        [ResponseType(typeof(Sht15))]
        public async Task<IHttpActionResult> PostSht15(Sht15 sht15)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sht15.Add(sht15);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Sht15Exists(sht15.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sht15.Id }, sht15);
        }

        // DELETE: api/Sht15/5
        [ResponseType(typeof(Sht15))]
        public async Task<IHttpActionResult> DeleteSht15(string id)
        {
            Sht15 sht15 = await db.Sht15.FindAsync(id);
            if (sht15 == null)
            {
                return NotFound();
            }

            db.Sht15.Remove(sht15);
            await db.SaveChangesAsync();

            return Ok(sht15);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sht15Exists(Guid id)
        {
            return db.Sht15.Count(e => e.Id == id) > 0;
        }
    }
}