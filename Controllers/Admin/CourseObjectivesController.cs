using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyllabusMaker.Controllers.Admin
{
    public class CourseObjectivesController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: CourseObjectives
        public ActionResult Index(int id)
        {
            Session["subjectId"] = id;
            var q = db.CourseObjectives.Where(x => x.CourseId == id).ToList();
            var data = db.CourseObjectives.Find(id);
            var tuple = new Tuple<CourseObjective, List<CourseObjective>>(data, q);

            return View(tuple);
        }

   
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            var c = new CourseObjective();
            c.CourseId = (int)Session["subjectId"];
            c.Objectives = Convert.ToString(frm["obj"]);
            db.CourseObjectives.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "CourseObjectives", Action = "Index", id = (int)Session["subjectId"] }));
        }
    }
}