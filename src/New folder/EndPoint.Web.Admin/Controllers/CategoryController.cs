using AtrinCode.Infrastructures.EFCore.Contexts;
using AtrinCode.Core.Contracts.Services.Articles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AtrinCode.Core.Domain.Entities.Articles;

namespace EndPoint.Web.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: ArticleCategoryController
        public ActionResult Index()
        {
            var model = _categoryService.GetAll();
            return View(model);
        }

        // GET: ArticleCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category articleCategory)
        {
            _categoryService.Add(articleCategory);

            //TempData["ErrorMes"] = "information is wrong";
            //return View();

            return RedirectToAction("Index", "Category");

        }

        // GET: ArticleCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _categoryService.GetCategory(id);
            return View(model);
        }

        // POST: ArticleCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category articleCategory)
        {
            _categoryService.Update(articleCategory);
            return RedirectToAction("Index");
        }

        // GET: ArticleCategoryController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ArticleCategoryController/Delete/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Json(new { success = true, Message = "delete is accepted" });
        }
    }
}
