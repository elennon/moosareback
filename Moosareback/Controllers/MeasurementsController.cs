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
    public class MeasurementsController : ApiController
    {
        private ReadingsContext db = new ReadingsContext();

        // GET: api/Measurements
        public IQueryable<Measurement> GetMeasurements()
        {
            return db.Measurements;
        }

        // GET: api/Measurements/5
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> GetMeasurement(Guid id)
        {
            Measurement measurement = await db.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            return Ok(measurement);
        }

        // PUT: api/Measurements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMeasurement(Guid id, Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != measurement._id)
            {
                return BadRequest();
            }

            db.Entry(measurement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
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

        // POST: api/Measurements
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> PostMeasurement(Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Measurements.Add(measurement);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MeasurementExists(measurement._id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = measurement._id }, measurement);
        }

        // DELETE: api/Measurements/5
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> DeleteMeasurement(Guid id)
        {
            Measurement measurement = await db.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            db.Measurements.Remove(measurement);
            await db.SaveChangesAsync();

            return Ok(measurement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeasurementExists(Guid id)
        {
            return db.Measurements.Count(e => e._id == id) > 0;
        }
    }
}