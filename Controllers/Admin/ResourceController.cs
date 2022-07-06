
using SyllabusGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SyllabusMaker.Controllers.Admin
{
    public class ResourceController : Controller
    {
        SyllabusMakerEntities db = new SyllabusMakerEntities();
        // GET: Resource

        public ActionResult Index(int id)
        {
            List<BookType> TypeList = db.BookTypes.ToList();

            ViewBag.TypeList = new SelectList(TypeList, "BooktypeId", "Type");
            var q = db.Books.Where(x => x.CourseId == id).ToList();
            var data = db.Books.Find(id);
            var tuple = new Tuple<Book, List<Book>>(data, q);

            return View(tuple);
        }

        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {

            List<BookType> TypeList = db.BookTypes.ToList();
            
            ViewBag.TypeList = new SelectList(TypeList, "BooktypeId", "Type");
            
            var b = new Book();
            b.CourseId = (int)Session["subjectId"];
            b.BookName = Convert.ToString(frm["obj"]);
            b.BookTypeId = Convert.ToInt32(frm["BookTypeId"]);
            db.Books.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "Resource", Action = "Index", id = (int)Session["subjectId"] }));
        }
       
    

    }
}