using Moosareback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moosareback.DAL
{
    public interface IRepository
    {
        void InsertReading(Measurement ms);
        List<Measurement> GetReadings();
    }
}
