using AtrinCode.Core.Contracts.Services.Articles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AtrinCode.Core.Domain.Entities.Articles;
using AtrinCode.Core.Domain.DTOs.Articles;

namespace EndPoint.Web.Admin.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        // GET: ArticleController
        public ActionResult Index()
        {
            var res = _articleService.GetAll();
            return View(res);
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Title", null);
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateArticleDTO article)
        {

            if (!ModelState.IsValid)
            {
                //  ViewBag.Message = "اطلاعات نادرست میباشد";
                ModelState.AddModelError("", "مقادیر را به درستی وارد کنید");
                ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Title", article.CategoryId);
                return View(article);
            }

            _articleService.InsertArticle(article);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _articleService.GetArticle(id);
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Title", model.CategoryId);
            return View(model);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditArticleDTO article)
        {
            _articleService.EditArticle(article);
            return RedirectToAction("Index");
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _articleService.DeleteArticle(id);
            return Json(new { Status = true, Message = "عملیات با موفقیت انجام شد" });
        }
    }
}
