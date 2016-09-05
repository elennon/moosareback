using Moosareback.DAL;
using Moosareback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moosareback.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo = new Repository();
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult GetReadings()
        {
            var readings = repo.GetReadings().Where(a => a.time > DateTime.Today.AddDays(-1)).OrderBy(b => b.time).ToList();
            List<TempVM> vm = new List<TempVM>();
            
            foreach (var item in readings)
            {
                vm.Add(new TempVM { Time = item.time.ToShortTimeString(), Temp = item.msg });
            }
            return Json(vm);

        }

        [HttpPost]
        public ActionResult GetPressureReadings()
        {
            var readings = repo.GetReadings().Where(a => a.time > DateTime.Today.AddDays(-1)).OrderBy(b => b.time).ToList();
            List<PressureVM> vm = new List<PressureVM>();
            foreach (var item in readings)
            {
                vm.Add(new PressureVM { Time = item.time.ToShortTimeString(), Pressure = item.msg });
            }
            return Json(vm);

        }

        public ActionResult Get()        // IEnumerable<Reading>
        {
            var readings = repo.GetReadings();
            return Json(readings);
        }
    }
}
