using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moosareback.Models
{
    public class TempVM
    {
        public double? Temp { get; set; }
        public string Time { get; set; }
    }

    public class PressureVM
    {
        public double? Pressure { get; set; }
        public string Time { get; set; }
    }
}