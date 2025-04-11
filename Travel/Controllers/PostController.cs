using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class PostController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult List()
        {
            return View(db.Posts.ToList());
        }

        [Authorize]
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(string Message)
        {
            Post post = new Post();

            var userid = User.Identity.GetUserId();
            var username = User.Identity.GetUserName();

            post.UserId = userid;
            post.DateTime = DateTime.Now;
            post.Message = Message;
            post.UserName = username;

            db.Posts.Add(post);
            db.SaveChanges();
            

            return RedirectToAction("List");
        }
    }
}