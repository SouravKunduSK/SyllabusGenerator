using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Edit(int? id)
        {


            var query = db.AssessmentStrategies.Where(m => m.AssessmentStrategieId== id).ToList().FirstOrDefault();
            return View(query);


        }

        [HttpPost]
        public ActionResult Edit(AssessmentStrategie c)
        {
            try
            {

                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "AssessmentStrategies");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex;
            }
            return RedirectToAction("Index", "AssessmentStrategies");
        }


        public ActionResult Delete(int? id)
        {
            try
            {

                var query = db.AssessmentStrategies.SingleOrDefault(m => m.AssessmentStrategieId == id);
                db.AssessmentStrategies.Remove(query);
                db.SaveChanges();
                return RedirectToAction("Index", "AssessmentStrategies");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex;
            }
            return RedirectToAction("Index", "AssessmentStrategies");
        }

    }
}