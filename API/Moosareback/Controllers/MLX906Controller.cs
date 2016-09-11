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
    public class MLX906Controller : ApiController
    {
        private ReadingsContext db = new ReadingsContext();

        // GET: api/MLX906
        public IQueryable<MLX906> GetMLX906()
        {
            return db.MLX906;
        }

        // GET: api/MLX906/5
        [ResponseType(typeof(MLX906))]
        public async Task<IHttpActionResult> GetMLX906(Guid id)
        {
            MLX906 mLX906 = await db.MLX906.FindAsync(id);
            if (mLX906 == null)
            {
                return NotFound();
            }

            return Ok(mLX906);
        }

        // PUT: api/MLX906/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMLX906(Guid id, MLX906 mLX906)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mLX906.Id)
            {
                return BadRequest();
            }

            db.Entry(mLX906).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MLX906Exists(id))
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

        // POST: api/MLX906
        [ResponseType(typeof(MLX906))]
        public async Task<IHttpActionResult> PostMLX906(MLX906 mLX906)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MLX906.Add(mLX906);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MLX906Exists(mLX906.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mLX906.Id }, mLX906);
        }

        // DELETE: api/MLX906/5
        [ResponseType(typeof(MLX906))]
        public async Task<IHttpActionResult> DeleteMLX906(Guid id)
        {
            MLX906 mLX906 = await db.MLX906.FindAsync(id);
            if (mLX906 == null)
            {
                return NotFound();
            }

            db.MLX906.Remove(mLX906);
            await db.SaveChangesAsync();

            return Ok(mLX906);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MLX906Exists(Guid id)
        {
            return db.MLX906.Count(e => e.Id == id) > 0;
        }
    }
}