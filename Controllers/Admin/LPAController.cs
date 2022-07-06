using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyllabusGenerator.Controllers.Admin
{
    public class LPAController : Controller
    {
        // GET: LPA
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        public ActionResult Index(int id)
        {
            List<AssessmentStrategie> AssemntList = db.AssessmentStrategies.ToList();

            ViewBag.AssemntList = new SelectList(AssemntList, "AssesmentStrategieId", "Strategies");
            var q = db.LPAssessmentStrategies.Where(x => x.PlanId == id).ToList();
            var data = db.LPAssessmentStrategies.Find(id);
            var tuple = new Tuple<LPAssessmentStrategie, List<LPAssessmentStrategie>>(data, q);

            return View(tuple);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            List<AssessmentStrategie> AssemntList = db.AssessmentStrategies.ToList();

            ViewBag.AssemntList = new SelectList(AssemntList, "AssesmentStrategieId", "Strategies");

            var b = new LPAssessmentStrategie();
            b.CourseId = (int)Session["subjectId"];
            b.AssessmentStrategieId = Convert.ToInt32(frm["asmntId"]);
            b.PlanId = (int)Session["planId"];
            db.LPAssessmentStrategies.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "LPA", Action = "Index", id = (int)Session["planId"] }));
        }
    }
}