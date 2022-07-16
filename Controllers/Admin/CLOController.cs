using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyllabusMaker.Controllers.Admin
{
    public class CLOController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: CLO


        public ActionResult Index(int?id)
        {
            var q = db.CLOes.Where(x => x.CourseId == id).ToList();
            

            return View(q);
        }

        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            var c = new CLO();
            c.CourseId = (int)Session["subjectId"];
            c.Outcomes = Convert.ToString(frm["obj"]);
            db.CLOes.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "CLO", Action = "Index", id = c.CourseId }));
        }
    }
}