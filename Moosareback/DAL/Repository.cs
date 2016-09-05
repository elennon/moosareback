using Moosareback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moosareback.DAL
{
    public class Repository : IRepository
    {
        ReadingsContext db = new ReadingsContext();
        object locker = new object();

        public void InsertReading(Measurement ms)
        {
            //Building b = new Building { BuildingId = Guid.NewGuid(), Location = "here", Name = "house" };
            //db.Buildings.Add(b);
            //db.SaveChanges();

            //Pi p = new Pi { Building = b, BuildingId = b.BuildingId, Name = "P1", PiId = Guid.NewGuid() };
            //db.Pis.Add(p);
            //db.SaveChanges();

            //rd.Building = b;
            //rd.BuildingId = b.BuildingId;
            //rd.PiId = p.PiId;
            try
            {
                db.Measurements.Add(ms);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Measurement> GetReadings()
        {
            lock (locker)
            {
                //db.Measurements.Add(new Measurement() { _id = "dummy", createdAt = "jan 1", msg = 15 });
                //db.SaveChanges();
                var gg = db.Measurements.OrderByDescending(a => a.time).ToList();
                var tf = db.Measurements.ToList().Where(a => a.time > DateTime.Today.AddDays(-1)).ToList();
                return tf;
            }
        }
    }
}