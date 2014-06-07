using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Areas.Admin.Controllers
{
    public class AdminController : Controller
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

        public ActionResult Edit(int id)
        {
            var model = _db.Topics.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(topic).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        public ActionResult Delete(int id)
        {
            var topic = _db.Topics.Find(id);
            return View(topic);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfrimed(int id)
        {
            var topic = _db.Topics.Find(id);
            _db.Topics.Remove(topic);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
