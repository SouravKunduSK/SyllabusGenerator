
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


            var p = db.LearningPlans.Find(id);
            var ci = db.LearningPlans.Where(x => x.CourseId == id).ToList();
           // var pi = ci.Where(x => x.PlanId == p.PlanId).ToList();
          //  ViewBag.pi = pi;
            ViewBag.ci = ci;
            //LessonPlan lp = new LessonPlan();
            //var q = db.LessonPlans.Where(x => x.CourseId == id).ToList();
            Session["courseId"] = id;
          //  return View(pi);
          return View();
        }

        public ActionResult Create()
        {

            List<Course> CourseList = db.Courses.ToList();
            ViewBag.CourseList = new SelectList(CourseList, "CourseId", "CourseCode");
            //List<CLO> CloList = db.CLOes.ToList();
            //ViewBag.CLOId = new SelectList(CloList, "CLOId", "Outcomes");
            ViewBag.CLOId = new SelectList(db.CLOes, "CLOId", "Outcomes");
            ViewBag.TimeLineId = new SelectList(db.Weeks, "WeekId", "Timeline");

            ViewBag.AssessmentStrategieId = new SelectList(db.AssessmentStrategies, "AssessmentStrategieId", "Strategies");
            ViewBag.TeachingStrategieId = new SelectList(db.TeachingStrategies, "TeachingStrategieId", "Strategies");

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
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "LPCLO", Action = "Index", id = (int)Session["planId"], cid = (int)Session["courseId"] }));

            //return RedirectToAction("Index/"+idd+ "");
            
            //ViewBag.Message = "Data Saved Successfully!";
            //return View();
        }
    }
}