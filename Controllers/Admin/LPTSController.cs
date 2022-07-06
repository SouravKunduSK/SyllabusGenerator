using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyllabusGenerator.Controllers.Admin
{
    public class LPTSController : Controller
    {
        // GET: LPTS
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        public ActionResult Index(int id)
        {
            List<TeachingStrategie> StrategieList = db.TeachingStrategies.ToList();

            ViewBag.StrategieList = new SelectList(StrategieList, "TeachingStrategieId", "Strategies");
            var q = db.LPTeachingStrategies.Where(x => x.PlanId == id).ToList();
            var data = db.LPTeachingStrategies.Find(id);
            var tuple = new Tuple<LPTeachingStrategie, List<LPTeachingStrategie>>(data, q);

            return View(tuple);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            List<TeachingStrategie> StrategieList = db.TeachingStrategies.ToList();

            ViewBag.StrategieList = new SelectList(StrategieList, "TeachingStrategieId", "Strategies");

            var b = new LPTeachingStrategie();
            b.CourseId = (int)Session["subjectId"];
            b.TeachingStrategieId = Convert.ToInt32(frm["tsId"]);
            b.PlanId = (int)Session["planId"];
            db.LPTeachingStrategies.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "LPTS", Action = "Index", id = (int)Session["planId"] }));
        }
    }
}