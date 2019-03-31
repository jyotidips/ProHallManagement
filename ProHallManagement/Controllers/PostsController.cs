using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProHallManagement.Helpers;
using ProHallManagement.Models;
using ProHallManagement.ViewModel;

namespace ProHallManagement.Controllers
{
    public class PostsController : Controller
    {
        private DataContext db = new DataContext();
        private int AlbumId;

        // GET: Posts
        public ActionResult Index()
        {
            //            var id = (int)Session["Id"];
            var vm = new TotalViewModel
            {
                Posts = db.UPosts.ToList(),
                PImages = db.PImages.ToList(),
                UComments = db.UComments.ToList()
            };
            return View(vm);
        }

        public ActionResult SinglePost(int id)
        {

            var single = db.UPosts.Where(p => p.Id == id).SingleOrDefault();
            var vm = new TotalViewModel
            {
                Post = single,
                PImages = db.PImages.ToList(),

            };
            return View(vm);
        }


        // GET: Posts/Create
        public PartialViewResult Create()
        {
            return PartialView("_CreatePost");
        }

        [HttpPost]
        public ActionResult SubmitPost(TotalViewModel model)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn", "Users");
            }
            var userId = (int)Session["Id"];
            var user = db.Users.Find(userId);

            //if any album exists for the current user named POST album
            var album = db.UAlbums.SingleOrDefault(a => a.UserId == userId && a.Name.Contains("Post"));
            if (album == null)//if no album exists for current user
            {
                var newPostAlbum = new UAlbum
                {
                    Name = "Post",
                    UserId = userId
                };
                db.UAlbums.Add(newPostAlbum);
                db.SaveChanges();
                this.AlbumId = newPostAlbum.Id;
            }//new album is created
            else
            {
                this.AlbumId = album.Id;
            }
            //create post now
            var post = new UPost
            {
                Title = model.Post.Title,
                Description = model.Post.Description,
                UserId = userId,
                CreatedAt = DateTime.Now.Date,
                UpdatedAt = DateTime.Now.Date

            };
            db.UPosts.Add(post);
            db.SaveChanges();

            //end Post
            string fileName = Path.GetFileNameWithoutExtension(model.File.FileName);
            string extension = Path.GetExtension(model.File.FileName);
            fileName = fileName + DateTime.Now.ToString("dd-MMMM-yyyy-hh.mm-tt") + extension;

            string fName = fileName;
            fileName = Path.Combine(Server.MapPath("/Uploads/Images/Post/"), fileName.Replace(" ", "-"));
            model.File.SaveAs(fileName);

            //----------------------------------------------------------------------------------------

            var vm = new TotalViewModel
            {
                PImage = new PImage
                {
                    ImageUrl = "/Uploads/Images/Post/" + fName.Replace(" ", "-"),
                    PostId = post.Id,
                    AlbumId = this.AlbumId,
                    UserId = userId,
                    IsCoverPic = false,
                    IsProfilePic = false,
                    Title = "Post-Pic-of-" + user.Id + "-" + user.Name.Replace(" ", "-") + "-at-" + DateTime.Now.ToString("dd-MMMM-yyyy-hh.mm-ss-tt"),
                }
            };
            db.PImages.Add(vm.PImage);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }



        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPost post = db.UPosts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult SetStatusTrue(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPost post = db.UPosts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            post.Status = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult SetStatusFalse(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPost post = db.UPosts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            post.Status = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult SupportUp(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPost post = db.UPosts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            post.Support += post.Support;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult SupportDown(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPost post = db.UPosts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            post.Unsupport += post.Unsupport;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            if (Session["Id"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var userId = (int)Session["Id"];
            var user = db.Users.Find(userId);


            UPost post = db.UPosts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            List<PImage> images = db.PImages.Where(c => c.PostId == post.Id && c.UserId == userId).ToList();

            var viewModel = new TotalViewModel
            {
                Post = post,
                PImages = images
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> RemovePic(int id, TotalViewModel totalView)
        {

            var current = await db.PImages.FindAsync(id);

            //remove pic from folder too
            var fullPath = Server.MapPath(current.ImageUrl);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            db.PImages.Remove(current);
            await db.SaveChangesAsync();
            var sid = (int)TempData["id"];

            return RedirectToAction("Edit", new { id = sid });
        }



        //        out

        //        GET: Posts/Edit/5
        //        public ActionResult Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            Post post = db.Posts.Find(id);
        //            if (post == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", post.StudentId);
        //            return View(post);
        //        }
        //
        //
        //
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit([Bind(Include = "Id,Title,Description,StudentId")] Post post)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Entry(post).State = EntityState.Modified;
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", post.StudentId);
        //            return View(post);
        //        }

        //        out



        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPost post = db.UPosts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UPost post = db.UPosts.Find(id);
            db.UPosts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
