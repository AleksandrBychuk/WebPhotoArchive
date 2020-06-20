using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPhotoArchive.Models;
using System.IO;
using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebPhotoArchive.Controllers
{
    public class HomeController : Controller
    {
        WebArchiveContext db = new WebArchiveContext();
        [Authorize]
        public ActionResult Index()//новости
        {
            #region My Id, variable 'i' for get it
            int i = 0;
            var id = from c in db.Users where c.Login == User.Identity.Name select c.Id;
            foreach (var t in id)
            {
                i = t;
            }
            #endregion
            var news_following_id = db.Follows.Where(u => u.FollowerId == i).Select(u => u.FollowingId);
            IQueryable<Post> list_news = null;
            list_news = db.Posts.Where(u => news_following_id.Contains(u.UserDoId)).OrderByDescending(p => p.Time);
            if (list_news.Any()) 
            {
                ViewBag.News = list_news;
            } else ViewBag.News = null;
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult UserProfile(int id)
        {
            var user = db.Users.Where(u => u.Id == id);
            ViewBag.User = user;
            var post = db.Posts.Where(u => u.UserDoId == id).OrderByDescending(u => u.Id); // PostId
            ViewBag.Post = post;
            using (WebArchiveContext dbc = new WebArchiveContext())
            {
                int i = 0; // мой Ид
                var checkFollow = db.Follows.Where(f => f.FollowerId == i && f.FollowingId == id).Select(f => f);
                var deleteOrderDetails = from c in dbc.Users where c.Login == User.Identity.Name select c.Id;
                foreach (var t in deleteOrderDetails)
                {
                    i = t;
                }
                if (id == i)
                {
                    //если на своей стр
                }
                else
                {
                    if (checkFollow.Any())
                    {
                        ViewBag.btnName = "Отписаться";
                    }
                    else
                    {
                        ViewBag.btnName = "Подписаться";
                    }
                }
                var num_posts = dbc.Posts.Where(u => u.UserDoId == id).Count();
                var num_followers = dbc.Follows.Where(u => u.FollowingId == id).Count();//подпищики
                var num_following = dbc.Follows.Where(u => u.FollowerId == id).Count();//подписки
                var posts_n = dbc.Users.Where(u => u.Id == id).FirstOrDefault();
                posts_n.Postnum = num_posts;
                posts_n.Followers = num_followers;
                posts_n.Following = num_following;
                dbc.SaveChanges();
            }
            return View();
        }

        public ActionResult UserGetId()
        {
            int i = 0;
            var deleteOrderDetails = from c in db.Users where c.Login == User.Identity.Name select c.Id;
            foreach (var t in deleteOrderDetails)
            {
                i = t;
            }
            return RedirectToAction("UserProfile/" + i);
        }

        public ActionResult Follow()
        {
            int i = 0;
            int id = int.Parse(Request.UrlReferrer.Segments[3]); // id на кого подписываемся
            var deleteOrderDetails = from c in db.Users where c.Login == User.Identity.Name select c.Id;
            foreach (var t in deleteOrderDetails)
            {
                i = t; // мой id
            }
            var checkFollow = db.Follows.Where(f=>f.FollowerId == i && f.FollowingId == id).Select(f=>f);
            if (id == i)
            {
                //none
            }
            else
            {
                if (checkFollow.Any())
                {
                    using (WebArchiveContext dbc = new WebArchiveContext())
                    {
                        foreach (var check in checkFollow)
                        {
                            dbc.Follows.Remove(check);
                        }
                        dbc.SaveChanges();
                    }
                }
                else 
                {
                    using (WebArchiveContext dbc = new WebArchiveContext())
                    {
                        //подписка
                        dbc.Follows.Add(new Follow { FollowerId = i, FollowingId = id, Time = DateTime.Now });
                        dbc.SaveChanges();
                    }
                }
            }
            return RedirectToAction("UserProfile/" + id);
        }

        [HttpPost]
        public ActionResult Post(Post p, HttpPostedFileBase uploadImage, string description)
        {
            int i = 0;
            var deleteOrderDetails = from c in db.Users where c.Login == User.Identity.Name select c.Id;
            foreach (var t in deleteOrderDetails)
            {
                i = t;
            }
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                //считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                //установка массива байтов
                p.Photo = imageData;
                p.UserDoId = i;
                p.UserDoName = User.Identity.Name;
                p.Time = DateTime.Now;
                p.Description = description;
                db.Posts.Add(p);
                db.SaveChanges();
            }
            else return HttpNotFound();

            return RedirectToAction("UserProfile/" + i);
        }

        public ActionResult LikeSystem(int id)
        {
            #region My Id, variable 'i' for get it
            int i = 0;
            var id_too = from c in db.Users where c.Login == User.Identity.Name select c.Id;
            foreach (var t in id_too)
            {
                i = t;
            }
            #endregion
            int id_like = 0;
            var found_like = db.Likes.Where(u => u.LikerId == i).Where(u => u.LikingId == id).Select(u => u.Id);
            foreach (var t in found_like)
            {
                id_like = t;
            }
            if (id_like == 0)
            {
                using (WebArchiveContext dbc = new WebArchiveContext())
                {
                    dbc.Likes.Add(new Like { LikerId = i, LikingId = id, Time = DateTime.Now });
                    dbc.SaveChanges();
                }
            }
            else
            {
                using (WebArchiveContext dbc = new WebArchiveContext())
                {
                    foreach (var t in found_like)
                    {
                        Like like = dbc.Likes.Find(t);
                        dbc.Likes.Remove(like);
                    }
                    dbc.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditAvatar(HttpPostedFileBase uploadImage)
        {
            int i = 0;
            var deleteOrderDetails = from c in db.Users where c.Login == User.Identity.Name select c.Id;
            foreach (var t in deleteOrderDetails)
            {
                i = t;
            }
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                var photo = db.Users.Where(u => u.Id == i).FirstOrDefault();
                photo.Photo = imageData;
                db.SaveChanges();
                return RedirectToAction("UserProfile/" + i);
            }
            else 
            {
                var photo = db.Users.Where(u => u.Id == i).FirstOrDefault();
                photo.Photo = null;
                db.SaveChanges();
                return RedirectToAction("UserProfile/" + i);
            }
        }

        [HttpPost]
        public ActionResult Comment(Comment comment, int? id_post)
        {
            comment.Time = DateTime.Now;
            comment.PostId = id_post;
            comment.NameComment = User.Identity.Name;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Comment", "Home", new { id_post });
        }

        [HttpGet]
        public ActionResult Comment(int id_post)
        {
            using (WebArchiveContext dbc = new WebArchiveContext())
            {
                var post = dbc.Posts.Where(p => p.Id == id_post).ToList();
                var comments = dbc.Comments.Where(p => p.PostId == id_post).ToList();
                ViewBag.Post = post;
                ViewBag.Comments = comments;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Search(string textSearch) 
        {
            string text1 = textSearch;
            var searchresult = db.Users.Where(u => u.Login == text1);
            return PartialView(searchresult);
        }

        [HttpGet]
        public ActionResult Dialogs()
        {
            #region My Id, variable 'i' for get it
            int i = 0;
            var id_too = from c in db.Users where c.Login == User.Identity.Name select c.Id;
            foreach (var t in id_too)
            {
                i = t;
            }
            #endregion
            var dialog = db.Dialogs.Where(d => d.FromId == i || d.ToId == i).ToList();
            return View(dialog);
        }

        [HttpGet]
        public ActionResult Chat(int id)
        {
            var dialog_check = db.Dialogs.Where(d => d.FromName == User.Identity.Name || d.ToName == User.Identity.Name).Select(d => d);
            if (dialog_check.Any())
            {
                var messages = db.Messages.Where(m => m.DialogId == id).ToList();
                return View(messages);
            }
            else 
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult MessagesAJAX(Message message)
        {
            int dialogId = int.Parse(Request.UrlReferrer.Segments[3]);
            message.Time = DateTime.Now;
            message.Name = User.Identity.Name;
            message.DialogId = dialogId;
            db.Messages.Add(message);
            db.SaveChanges();
            var messages = db.Messages.Where(m => m.DialogId == dialogId).ToList();
            return PartialView(messages);
        }

        public ActionResult Message()
        {
            #region My Id, variable 'i' for get it
            int i = 0;
            var id_too = from c in db.Users where c.Login == User.Identity.Name select c.Id;
            foreach (var t in id_too)
            {
                i = t;
            }
            #endregion
            int idTo = int.Parse(Request.UrlReferrer.Segments[3]);
            string name = null;
            var name_too = from c in db.Users where c.Id == idTo select c.Login;
            foreach (var t in name_too)
            {
                name = t;
            }
            Dialog dialog = null;
            using(WebArchiveContext dbc = new WebArchiveContext()) 
            {
                dialog = dbc.Dialogs.FirstOrDefault(d=>((d.FromId == i && d.ToId == idTo) || (d.FromId == idTo && d.ToId == i)));
            }
            if (dialog == null)
            {
                using (WebArchiveContext dbc = new WebArchiveContext())
                {
                    dbc.Add(new Dialog { FromId = i, ToId = idTo, FromName = User.Identity.Name, ToName = name, Time = DateTime.Now });
                    dbc.SaveChanges();
                    var idd = dbc.Dialogs.Where(d => ((d.FromId == i && d.ToId == idTo) || (d.FromId == idTo && d.ToId == i))).Select(d => d.Id);
                    int dialog_id = 0;
                    foreach (var idd_d in idd)
                        dialog_id = idd_d;
                    return RedirectToAction("Chat/" + dialog_id);
                }
            }
            else 
            {
                var idd = db.Dialogs.Where(d => ((d.FromId == i && d.ToId == idTo) || (d.FromId == idTo && d.ToId == i))).Select(d=>d.Id);
                int dialog_id = 0;
                foreach (var idd_d in idd)
                    dialog_id = idd_d;
                return RedirectToAction("Chat/"+dialog_id);
            }
        }
    }
}