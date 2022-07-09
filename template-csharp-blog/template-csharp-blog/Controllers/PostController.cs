using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using template_csharp_blog.Models;

namespace template_csharp_blog.Controllers
{
    public class PostController : Controller
    {
        public BlogContext db { get; set; }

        public PostController(BlogContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(db.Posts.ToList().Where(p => p.Id == id).FirstOrDefault());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            return View(new Post());
        }

        [HttpPost]

        public IActionResult Create(Post model)
        {
            db.Posts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Post post = db.Posts.Find(id);
            List<Category> categories = db.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(post);
        }

        [HttpPost]

        public IActionResult Update(Post model)
        {
            db.Posts.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        [HttpPost]

        public IActionResult Delete(Post model)
        {
            db.Posts.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
