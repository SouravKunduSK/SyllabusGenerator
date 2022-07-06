using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View(q);
        }
    }
}