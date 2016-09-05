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
    public class CavityTempsController : ApiController
    {
        private ReadingsContext db = new ReadingsContext();

        // GET: api/CavityTemps
        public IQueryable<CavityTemp> GetCavityTemps()
        {
            return db.CavityTemps;
        }

        // GET: api/CavityTemps/5
        [ResponseType(typeof(CavityTemp))]
        public async Task<IHttpActionResult> GetCavityTemp(Guid id)
        {
            CavityTemp cavityTemp = await db.CavityTemps.FindAsync(id);
            if (cavityTemp == null)
            {
                return NotFound();
            }

            return Ok(cavityTemp);
        }

        // PUT: api/CavityTemps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCavityTemp(Guid id, CavityTemp cavityTemp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cavityTemp._id)
            {
                return BadRequest();
            }

            db.Entry(cavityTemp).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CavityTempExists(id))
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

        // POST: api/CavityTemps
        [ResponseType(typeof(CavityTemp))]
        public async Task<IHttpActionResult> PostCavityTemp(CavityTemp cavityTemp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CavityTemps.Add(cavityTemp);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CavityTempExists(cavityTemp._id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cavityTemp._id }, cavityTemp);
        }

        // DELETE: api/CavityTemps/5
        [ResponseType(typeof(CavityTemp))]
        public async Task<IHttpActionResult> DeleteCavityTemp(Guid id)
        {
            CavityTemp cavityTemp = await db.CavityTemps.FindAsync(id);
            if (cavityTemp == null)
            {
                return NotFound();
            }

            db.CavityTemps.Remove(cavityTemp);
            await db.SaveChangesAsync();

            return Ok(cavityTemp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CavityTempExists(Guid id)
        {
            return db.CavityTemps.Count(e => e._id == id) > 0;
        }
    }
}