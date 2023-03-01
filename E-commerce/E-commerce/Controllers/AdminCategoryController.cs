using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Controllers
{
    public class AdminCategoryController : Controller
    {

        CategoryRepository categoryRepository = new CategoryRepository();
        // GET: AdminCategory
        public ActionResult Index()
        {
            return View(categoryRepository.List());
        }

        public ActionResult Create()
        {
            return View();        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Insert(category);

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An Error Occured");
            return View();

        }

        public ActionResult Update(int id)
        {
            var cat = categoryRepository.GetById(id);
            return View(cat);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Category data)
        {
            if (ModelState.IsValid)
            {
                var cat = categoryRepository.GetById(data.Id);
                cat.Description = data.Description;
                cat.Name = data.Name;
                categoryRepository.Update(cat);
                return RedirectToAction("Index");
            }
            return View(data);

        }

        public ActionResult Delete(int id)
        {
            var cat = categoryRepository.GetById(id);
            categoryRepository.Delete(cat);

            return RedirectToAction("Index");
        }

    }
}