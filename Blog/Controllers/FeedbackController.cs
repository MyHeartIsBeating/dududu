using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    /// <summary>
    /// Controller for add/view feedback for our site
    /// </summary>
    public class FeedbackController : Controller
    {
        BlogDb _db = new BlogDb();

        public ActionResult Index()
        {
            var feedbacks = from f in _db.Feedbacks
                            orderby f.Created descending
                            select f;

            return View(feedbacks);
        }


        [HttpPost]
        public ActionResult Index(Feedback feedback)
        {
            feedback.Created = DateTime.Now;

            if (ModelState.IsValid)
            {
                _db.Feedbacks.Add(feedback);
                _db.SaveChanges();
                return RedirectToAction("Index","Feedback");
            }
            else
                return View(feedback);
        }


    }
}
