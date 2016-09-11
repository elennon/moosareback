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
    public class Sdp610Controller : ApiController
    {
        private ReadingsContext db = new ReadingsContext();

        // GET: api/Sdp610
        public IQueryable<Sdp610> GetSdp610()
        {
            return db.Sdp610;
        }

        // GET: api/Sdp610/5
        [ResponseType(typeof(Sdp610))]
        public async Task<IHttpActionResult> GetSdp610(Guid id)
        {
            Sdp610 sdp610 = await db.Sdp610.FindAsync(id);
            if (sdp610 == null)
            {
                return NotFound();
            }

            return Ok(sdp610);
        }

        // PUT: api/Sdp610/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSdp610(Guid id, Sdp610 sdp610)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sdp610.Id)
            {
                return BadRequest();
            }

            db.Entry(sdp610).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sdp610Exists(id))
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

        // POST: api/Sdp610
        [ResponseType(typeof(Sdp610))]
        public async Task<IHttpActionResult> PostSdp610(Sdp610 sdp610)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sdp610.Add(sdp610);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Sdp610Exists(sdp610.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sdp610.Id }, sdp610);
        }

        // DELETE: api/Sdp610/5
        [ResponseType(typeof(Sdp610))]
        public async Task<IHttpActionResult> DeleteSdp610(Guid id)
        {
            Sdp610 sdp610 = await db.Sdp610.FindAsync(id);
            if (sdp610 == null)
            {
                return NotFound();
            }

            db.Sdp610.Remove(sdp610);
            await db.SaveChangesAsync();

            return Ok(sdp610);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sdp610Exists(Guid id)
        {
            return db.Sdp610.Count(e => e.Id == id) > 0;
        }
    }
}