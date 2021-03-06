using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyllabusGenerator.Controllers.Admin
{
    public class LPCLOController : Controller
    {
        // GET: LPCLO
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        public ActionResult Index(int id, int cid)
        {
            //var cid = (int)Session["subjectId"];
            List<CLO> CloList = db.CLOes.Where(x => x.CourseId == cid).ToList();

            ViewBag.CloList = new SelectList(CloList, "CLOId", "Outcomes");
            var q = db.LPCLOes.Where(x => x.PlanId == id).ToList();
            var data = db.LPCLOes.Find(id);
            var tuple = new Tuple<LPCLO, List<LPCLO>>(data, q);

            return View(tuple);
        }
        [HttpPost]
        public ActionResult Create(FormCollection frm, int? cid)
        {
            List<CLO> CloList = db.CLOes.Where(x=>x.CourseId== cid).ToList();

            ViewBag.CloList = new SelectList(CloList, "CLOId", "Outcomes");

            var b = new LPCLO();
            b.CourseId = (int)Session["subjectId"];
            b.CLOId = Convert.ToInt32(frm["CloId"]);
            b.PlanId = (int)Session["planId"];
            db.LPCLOes.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "LPCLO", Action = "Index", id = (int)Session["planId"], cid = (int)Session["subjectId"] }));
        }
    }
}