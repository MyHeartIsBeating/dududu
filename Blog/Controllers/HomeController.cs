using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        BlogDb _db = new BlogDb();

        public ActionResult Index()
        {
            var model = from r in _db.Topics
                        orderby r.Created descending
                        select r;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Topic topic) 
        {
            topic.Created = DateTime.Now;
            if (ModelState.IsValid)
            {
                _db.Topics.Add(topic);
                _db.SaveChanges();
                return Redirect("Index");
            }
            else
                return View(topic);
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
