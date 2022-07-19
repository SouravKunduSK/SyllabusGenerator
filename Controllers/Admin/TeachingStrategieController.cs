
using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyllabusMaker.Controllers.Admin
{
    public class TeachingStrategieController : Controller
    {
        // GET: TeachingStrategie
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        public ActionResult Index()
        {
            var q = db.TeachingStrategies.ToList();
            return View(q);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TeachingStrategie t)
        {
            db.TeachingStrategies.Add(t);
            db.SaveChanges();
            return RedirectToAction ("Index","TeachingStrategie");
        }
    
  
        public ActionResult Edit(int? id)
        {


            var query = db.TeachingStrategies.Where(m => m.TeachingStrategieId == id).ToList().FirstOrDefault();
            return View(query);


        }

        [HttpPost]
        public ActionResult Edit(TeachingStrategie c)
        {
            try
            {

                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "TeachingStrategie");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex;
            }
            return RedirectToAction("Index", "TeachingStrategie");
        }
    }

}