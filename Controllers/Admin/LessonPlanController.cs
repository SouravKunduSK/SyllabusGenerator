
using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyllabusMaker.Controllers.Admin
{
    public class LessonPlanController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();



        // GET: LessonPlan


        public ActionResult SubCode()
        {
            var q = db.Courses.ToList();
            return View(q);
        }

       
        public ActionResult Index(int?id)
        {
            Session["courseId"] = id;
            var q = db.LearningPlans.Where(x=>x.CourseId==id).ToList();
            return View(q);
        }

        public ActionResult Create()
        {

            List<Course> CourseList = db.Courses.ToList();
            ViewBag.CourseList = new SelectList(CourseList, "CourseId", "CourseCode");
            //List<CLO> CloList = db.CLOes.ToList();
            //ViewBag.CLOId = new SelectList(CloList, "CLOId", "Outcomes");
            ViewBag.CLOId = new MultiSelectList(db.CLOes, "CLOId", "Outcomes");
            ViewBag.TimeLineId = new SelectList(db.Weeks, "WeekId", "Timeline");

            ViewBag.AssessmentStrategieId = new MultiSelectList(db.AssessmentStrategies, "AssessmentStrategieId", "Strategies");
            ViewBag.TeachingStrategieId = new MultiSelectList(db.TeachingStrategies, "TeachingStrategieId", "Strategies");

            return View();
        }
        [HttpPost]
        public ActionResult Create(LearningPlan learningPlan)
        {
            var idd = (int)Session["courseId"];
            learningPlan.CourseId = (int) Session["courseId"];
            db.LearningPlans.Add(learningPlan);
            db.SaveChanges();
            Session["subjectId"] = learningPlan.CourseId;
            Session["planId"] = learningPlan.PlanId;
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "LPCLO", Action = "Index", id = (int)Session["planId"] }));

            //return RedirectToAction("Index/"+idd+ "");
            
            //ViewBag.Message = "Data Saved Successfully!";
            //return View();
        }
    }
}