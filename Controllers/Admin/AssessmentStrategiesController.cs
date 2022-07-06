using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyllabusGenerator.Controllers.Admin
{
    public class AssessmentStrategiesController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: AssessmentStrategies
        public ActionResult Index()
        {
            var q = db.AssessmentStrategies.ToList();
            return View(q);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AssessmentStrategie a)
        {
            db.AssessmentStrategies.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index", "AssessmentStrategies");
        }

    }
}