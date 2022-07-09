using Microsoft.AspNetCore.Mvc;
using template_csharp_blog.Models;

namespace template_csharp_blog.Controllers
{
    public class CategoryController : Controller
    {
        public BlogContext db;
        
        public CategoryController(BlogContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public IActionResult Details(int id)         //TODO: show all posts for category in category/details
        {
            return View(db.Categories.ToList().Where(c => c.Id == id).FirstOrDefault());
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]

        public IActionResult Create(Category model)
        {
            List<Category> categories = db.Categories.ToList();
            for(int i = 0; i < categories.Count; i++)
            {
                if (categories[i].Name == model.Name)
                {
                    ViewBag.Warning = "That category already exists!";    //TODO: Does not seem to get to Viewbag.Warning, nothing happens when 'create' is clicked.
                    return View(model);
                }
            }
            db.Categories.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Category category = db.Categories.Find(id);
            if(category == null)
            {
                return View("Error");
            }
            return View(category);
        }

        [HttpPost]

        public IActionResult Update(Category model)
        {
            db.Categories.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]

        public IActionResult Delete(Category model)
        {
            db.Categories.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
