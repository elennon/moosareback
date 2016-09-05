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
    public class Bmp180Controller : ApiController
    {
        private ReadingsContext db = new ReadingsContext();

        // GET: api/Bmp180
        public IQueryable<Bmp180> GetBmp180()
        {
            return db.Bmp180;
        }

        // GET: api/Bmp180/5
        [ResponseType(typeof(Bmp180))]
        public async Task<IHttpActionResult> GetBmp180(string id)
        {
            Bmp180 bmp180 = await db.Bmp180.FindAsync(id);
            if (bmp180 == null)
            {
                return NotFound();
            }

            return Ok(bmp180);
        }

        // PUT: api/Bmp180/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBmp180(Guid id, Bmp180 bmp180)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bmp180._id)
            {
                return BadRequest();
            }

            db.Entry(bmp180).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bmp180Exists(id))
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

        // POST: api/Bmp180
        [ResponseType(typeof(Bmp180))]
        public async Task<IHttpActionResult> PostBmp180(Bmp180 bmp180)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bmp180.Add(bmp180);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (Bmp180Exists(bmp180._id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bmp180._id }, bmp180);
        }

        // DELETE: api/Bmp180/5
        [ResponseType(typeof(Bmp180))]
        public async Task<IHttpActionResult> DeleteBmp180(string id)
        {
            Bmp180 bmp180 = await db.Bmp180.FindAsync(id);
            if (bmp180 == null)
            {
                return NotFound();
            }

            db.Bmp180.Remove(bmp180);
            await db.SaveChangesAsync();

            return Ok(bmp180);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Bmp180Exists(Guid id)
        {
            return db.Bmp180.Count(e => e._id == id) > 0;
        }
    }
}