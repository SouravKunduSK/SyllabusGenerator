using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyllabusMaker.Controllers.Admin
{
    public class GSController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: GS

        public ActionResult SubCode()
        {
            var q = db.Courses.ToList();
            return View(q);
        }
        public ActionResult Index(int?id)
        {
            
            Session["courseId"] = id;
            /*TempData["msg"] = db.Courses.Where(x => x.CourseId == ).ToList();*/
            var q = db.LearningPlans.Where(x => x.CourseId == id).ToList();
            var r = db.Courses.Where(x => x.CourseId == id).ToList();
            ViewBag.courseDetail = db.Courses.Where(x => x.CourseId == id).ToList();
            ViewBag.cloDetail = db.CLOes.Where(x => x.CourseId == id).ToList();
            ViewBag.objective = db.CourseObjectives.Where(x => x.CourseId == id).ToList();
            ViewBag.lesonPlans = db.LessonPlans.Where(x => x.CourseId == id).ToList();
            ViewBag.assessments = db.AssessmentStrategies.ToList();
            ViewBag.textBook = db.Books.Where(x => x.BookType.BookTypeId == 1 && x.CourseId == id).ToList();
            ViewBag.refBook = db.Books.Where(x => x.BookType.BookTypeId == 2 && x.CourseId == id).ToList();

            var p = db.LearningPlans.Find(id);
            var ci = db.LearningPlans.Where(x => x.CourseId == id).ToList();
            ViewBag.ci = ci;


            return View();
        }

        public ActionResult GeneratePdf()
        {
            return new Rotativa.ActionAsPdf("Index", new RouteValueDictionary(new { Controller = "GS", Action = "Index", id = (int)Session["courseId"] }));
        }
    }
}