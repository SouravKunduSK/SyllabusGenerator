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
            List<AssessmentStrategie> AssesmntList = db.AssessmentStrategies.ToList();

            ViewBag.AssesmntList = new SelectList(AssesmntList, "AssessmentStrategieId", "Strategies");
            var q = db.LPAssessmentStrategies.Where(x => x.PlanId == id).ToList();
            var data = db.LPAssessmentStrategies.Find(id);
            var tuple = new Tuple<LPAssessmentStrategie, List<LPAssessmentStrategie>>(data, q);

            return View(tuple);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            List<AssessmentStrategie> AssesmntList = db.AssessmentStrategies.ToList();

            ViewBag.AssesmntList = new SelectList(AssesmntList, "AssessmentStrategieId", "Strategies");

            var b = new LPAssessmentStrategie();
            b.CourseId = (int)Session["subjectId"];
            b.AssessmentStrategieId = Convert.ToInt32(frm["AsmntId"]);
            b.PlanId = (int)Session["planId"];
            b.Strategies = db.AssessmentStrategies.Find(b.AssessmentStrategieId).Strategies.ToString();
            db.LPAssessmentStrategies.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "LPA", Action = "Index", id = (int)Session["planId"] }));
        }
    }
}