using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyllabusGenerator.Controllers.Admin
{
    public class CourseController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: Course
        public ActionResult Index()
        {
            var q = db.Courses.ToList();
            return View(q);
        }

        public ActionResult Create()
        {
            List<CourseType> TypeList = db.CourseTypes.ToList();
            ViewBag.TypeList = new SelectList(TypeList, "CourseTypeId", "Type");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course c)
        {
            List<CourseType> TypeList = db.CourseTypes.ToList();
            ViewBag.TypeList = new SelectList(TypeList, "CourseTypeId", "Type");
            if (c.CourseTypeId == 1)
            {
                c.MarksId = 1;
            }
            else
            {
                c.MarksId = 2;
            }
            db.Courses.Add(c);
            db.SaveChanges();
            Session["subjectId"] = c.CourseId;
            return RedirectToAction("Index",new RouteValueDictionary(new { Controller = "CourseObjectives", Action="Index", id =(int) Session["subjectId"] }));
            
        }
    }
}